using System.Collections.Generic;
using UnityEngine;

namespace SABI
{
    public static class Vector3IntExtensions
    {
        public static Vector3Int SetValue(this Vector3Int v, int value) =>
            new Vector3Int(value, value, value);

        #region With X

        public static Vector3Int WithX(this Vector3Int v, int x) => new Vector3Int(x, v.y, v.z);

        public static Vector3Int WithX(this Vector3Int v, Vector3Int target) =>
            new Vector3Int(target.x, v.y, v.z);

        public static Vector3Int WithAddX(this Vector3Int v, int x) =>
            new Vector3Int(v.x + x, v.y, v.z);

        public static Vector3Int WithSubtractX(this Vector3Int v, int x) =>
            new Vector3Int(v.x - x, v.y, v.z);

        public static Vector3Int WithMultiplyX(this Vector3Int v, int x) =>
            new Vector3Int(v.x * x, v.y, v.z);

        #endregion

        #region Set X

        public static Vector3Int SetX(this ref Vector3Int v, int x)
        {
            v = new Vector3Int(x, v.y, v.z);
            return v;
        }

        public static Vector3Int SetX(this ref Vector3Int v, Vector3Int target)
        {
            v = new Vector3Int(target.x, v.y, v.z);
            return v;
        }

        public static Vector3Int SetAddX(this ref Vector3Int v, int x)
        {
            v = new Vector3Int(v.x + x, v.y, v.z);
            return v;
        }

        public static Vector3Int SetSubtractX(this ref Vector3Int v, int x)
        {
            v = new Vector3Int(v.x - x, v.y, v.z);
            return v;
        }

        public static Vector3Int SetMultiplyX(this ref Vector3Int v, int x)
        {
            v = new Vector3Int(v.x * x, v.y, v.z);
            return v;
        }

        #endregion

        #region With Y

        public static Vector3Int WithY(this Vector3Int v, int y) => new Vector3Int(v.x, y, v.z);

        public static Vector3Int WithY(this Vector3Int v, Vector3Int target) =>
            new Vector3Int(v.x, target.y, v.z);

        public static Vector3Int WithAddY(this Vector3Int v, int y) =>
            new Vector3Int(v.x, v.y + y, v.z);

        public static Vector3Int WithSubtractY(this Vector3Int v, int y) =>
            new Vector3Int(v.x, v.y - y, v.z);

        public static Vector3Int WithMultiplyY(this Vector3Int v, int y) =>
            new Vector3Int(v.x, v.y * y, v.z);

        #endregion

        #region Set X

        public static Vector3Int SetY(this ref Vector3Int v, int y)
        {
            v = new Vector3Int(v.x, y, v.z);
            return v;
        }

        public static Vector3Int SetY(this ref Vector3Int v, Vector3Int target)
        {
            v = new Vector3Int(v.x, target.y, v.z);
            return v;
        }

        public static Vector3Int SetAddY(this ref Vector3Int v, int y)
        {
            v = new Vector3Int(v.x, v.y + y, v.z);
            return v;
        }

        public static Vector3Int SetSubtractY(this ref Vector3Int v, int y)
        {
            v = new Vector3Int(v.x, v.y - y, v.z);
            return v;
        }

        public static Vector3Int SetMultiplyY(this ref Vector3Int v, int y)
        {
            v = new Vector3Int(v.x, v.y * y, v.z);
            return v;
        }

        #endregion

        #region with Z
        public static Vector3Int WithZ(this Vector3Int v, int z) => new Vector3Int(v.x, v.y, z);

        public static Vector3Int WithZ(this Vector3Int v, Vector3Int target) =>
            new Vector3Int(v.x, v.y, target.z);

        public static Vector3Int WithAddZ(this Vector3Int v, int z) =>
            new Vector3Int(v.x, v.y, v.z + z);

        public static Vector3Int WithSubtractZ(this Vector3Int v, int z) =>
            new Vector3Int(v.x, v.y, v.z - z);

        public static Vector3Int WithMultiplyZ(this Vector3Int v, int z) =>
            new Vector3Int(v.x, v.y, v.z * z);

        #endregion

        #region Set X

        public static Vector3Int SetZ(this ref Vector3Int v, int z)
        {
            v = new Vector3Int(v.x, v.y, z);
            return v;
        }

        public static Vector3Int SetZ(this ref Vector3Int v, Vector3Int target)
        {
            v = new Vector3Int(v.x, v.y, target.z);
            return v;
        }

        public static Vector3Int SetAddZ(this ref Vector3Int v, int z)
        {
            v = new Vector3Int(v.x, v.y, v.z + z);
            return v;
        }

        public static Vector3Int SetSubtractZ(this ref Vector3Int v, int z)
        {
            v = new Vector3Int(v.x, v.y, v.z - z);
            return v;
        }

        public static Vector3Int SetMultiplyZ(this ref Vector3Int v, int z)
        {
            v = new Vector3Int(v.x, v.y, v.z * z);
            return v;
        }

        #endregion

        #region Clamp

        public static Vector3Int Clamp(this Vector3Int value, Vector3Int min, Vector3Int max)
        {
            return new Vector3Int(
                Mathf.Clamp(value.x, min.x, max.x),
                Mathf.Clamp(value.y, min.y, max.y),
                Mathf.Clamp(value.z, min.z, max.z)
            );
        }

        public static Vector3Int Max(this Vector3Int a, Vector3Int b) =>
            new Vector3Int(Mathf.Max(a.x, b.x), Mathf.Max(a.y, b.y), Mathf.Max(a.z, b.z));

        public static Vector3Int Min(this Vector3Int a, Vector3Int b) =>
            new Vector3Int(Mathf.Min(a.x, b.x), Mathf.Min(a.y, b.y), Mathf.Min(a.z, b.z));

        #endregion


        #region Vector 2 conversion

        public static Vector2 ToVector2XY(this Vector3Int v) => new Vector2(v.x, v.y);

        public static Vector2 ToVector2XZ(this Vector3Int v) => new Vector2(v.x, v.z);

        public static Vector2 ToVector2YZ(this Vector3Int v) => new Vector2(v.y, v.z);

        #endregion

        #region More


        public static Vector3Int GetClosest(
            this Vector3Int position,
            IEnumerable<Vector3Int> otherPositions
        )
        {
            var closest = Vector3Int.zero;
            var shortestDistance = Mathf.Infinity;

            foreach (var otherPosition in otherPositions)
            {
                var distance = (position - otherPosition).sqrMagnitude;

                if (distance < shortestDistance)
                {
                    closest = otherPosition;
                    shortestDistance = distance;
                }
            }

            return closest;
        }

        public static Vector3Int ScaleBy(this Vector3Int v, Vector3Int scale) =>
            new Vector3Int(v.x * scale.x, v.y * scale.y, v.z * scale.z);

        public static float Distance(this Vector3Int v, Vector3Int target) =>
            Vector3Int.Distance(v, target);
        #endregion

        public static Vector3Int Remap(
            this Vector3Int vector,
            Vector2Int sourceRange,
            Vector2Int targetRange
        ) =>
            new Vector3Int(
                vector.x.Remap(sourceRange, targetRange),
                vector.y.Remap(sourceRange, targetRange),
                vector.z.Remap(sourceRange, targetRange)
            );

        public static Vector3Int Abs(this Vector3Int vector) =>
            new(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));
    }
}
