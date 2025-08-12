using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SABI
{
    public static class SceneExtensions
    {
        /// <summary>
        /// Finds game object in scene.
        /// </summary>
        public static T FindObjectOfType<T>(this Scene scene, bool includeInactive = false)
            where T : Component
        {
            foreach (
                var mainParent in scene
                    .GetRootGameObjects()
                    .Where(item => item.activeSelf || includeInactive)
            )
            {
                if (mainParent.TryGetComponentInChildren<T>(out T component, includeInactive))
                    return component;
            }

            return null;
        }

        /// <summary>
        /// Finds game objects in scene.
        /// </summary>
        public static T[] FindObjectsOfType<T>(this Scene scene, bool includeInactive = false)
        {
            var filtered = scene
                .GetRootGameObjects()
                .Where(item => item.activeSelf || includeInactive);
            return filtered
                .SelectMany(gameObject => gameObject.GetComponentsInChildren<T>(includeInactive))
                .ToArray();
        }
    }
}
