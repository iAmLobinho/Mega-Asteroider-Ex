using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SABI
{
    public static class ObjectExtensions
    {
        public static void DestroyGameObject(this Object value, float delay = 0)
        {
            if (value == null)
                return;
            if (value is MonoBehaviour monoBehaviour)
                value = monoBehaviour.gameObject;
            if (value is Transform transform)
                value = transform.gameObject;

            if (!Application.isPlaying)
                Object.DestroyImmediate(value);
            else
                Object.Destroy(value, delay);
        }

        /// <summary>
        /// Checks if the object equals to any of the provided objects.
        /// </summary>
        public static bool EqualsToAny(this object obj, params object[] objects) =>
            objects.Any(o => o.Equals(obj));

        public static bool Spawn(
            this object obj,
            GameObject objectToInstantiate,
            float radius,
            int count,
            Vector3? boundsThatCantOverlap = null,
            Action<GameObject> OnObjectCreated = null
        )
        {
            int instancesToCreate = Mathf.RoundToInt(count);
            if (instancesToCreate <= 0)
                return false;
            Vector3 origin = Vector3.zero;
            if (obj is GameObject go)
                origin = go.transform.position;
            else if (obj is Component comp)
                origin = comp.transform.position;

            List<Vector3> placedPositions = new List<Vector3>();
            int placedCount = 0;
            int maxAttempts = 100 * instancesToCreate;

            while (placedCount < instancesToCreate && maxAttempts > 0)
            {
                maxAttempts--;

                Vector3 candidatePos = origin + Random.insideUnitSphere * radius;

                if (boundsThatCantOverlap != null)
                {
                    bool overlapFound = false;
                    foreach (var pos in placedPositions)
                    {
                        if (
                            Mathf.Abs(candidatePos.x - pos.x) < boundsThatCantOverlap.Value.x
                            && Mathf.Abs(candidatePos.y - pos.y) < boundsThatCantOverlap.Value.y
                            && Mathf.Abs(candidatePos.z - pos.z) < boundsThatCantOverlap.Value.z
                        )
                        {
                            overlapFound = true;
                            break;
                        }
                    }
                    if (overlapFound)
                        continue;
                }

                GameObject spawnedObject = Object.Instantiate(
                    objectToInstantiate,
                    candidatePos,
                    Quaternion.identity
                );
#if UNITY_EDITOR
                Undo.RegisterCreatedObjectUndo(spawnedObject, "SpawnedObject");
#endif

                OnObjectCreated?.Invoke(spawnedObject);

                placedPositions.Add(candidatePos);
                placedCount++;
            }

            return placedCount == instancesToCreate;
        }
    }
}
