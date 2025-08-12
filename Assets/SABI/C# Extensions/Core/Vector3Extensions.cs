using System.Collections.Generic;
using UnityEngine;

namespace SABI
{
    public static class Vector3Extensions
    {
        public static Vector3 SetValue(this Vector3 v, float value) =>
            new Vector3(value, value, value);

        #region With X

        public static Vector3 WithX(this Vector3 v, float x) => new Vector3(x, v.y, v.z);

        public static Vector3 WithPosX(this Vector3 v, Transform target) =>
            new Vector3(target.position.x, v.y, v.z);

        public static Vector3 WithX(this Vector3 v, Vector3 target) =>
            new Vector3(target.x, v.y, v.z);

        public static Vector3 WithAddX(this Vector3 v, float x) => new Vector3(v.x + x, v.y, v.z);

        public static Vector3 WithSubtractX(this Vector3 v, float x) =>
            new Vector3(v.x - x, v.y, v.z);

        public static Vector3 WithMultiplyX(this Vector3 v, float x) =>
            new Vector3(v.x * x, v.y, v.z);

        #endregion

        #region Set X

        public static Vector3 SetX(this ref Vector3 v, float x)
        {
            v = new Vector3(x, v.y, v.z);
            return v;
        }

        public static Vector3 SetX(this ref Vector3 v, Vector3 target)
        {
            v = new Vector3(target.x, v.y, v.z);
            return v;
        }

        public static Vector3 SetAddX(this ref Vector3 v, float x)
        {
            v = new Vector3(v.x + x, v.y, v.z);
            return v;
        }

        public static Vector3 SetSubtractX(this ref Vector3 v, float x)
        {
            v = new Vector3(v.x - x, v.y, v.z);
            return v;
        }

        public static Vector3 SetMultiplyX(this ref Vector3 v, float x)
        {
            v = new Vector3(v.x * x, v.y, v.z);
            return v;
        }

        #endregion

        #region With Y

        public static Vector3 WithY(this Vector3 v, float y) => new Vector3(v.x, y, v.z);

        public static Vector3 WithPosY(this Vector3 v, Transform target) =>
            new Vector3(v.x, target.position.y, v.z);

        public static Vector3 WithY(this Vector3 v, Vector3 target) =>
            new Vector3(v.x, target.y, v.z);

        public static Vector3 WithAddY(this Vector3 v, float y) => new Vector3(v.x, v.y + y, v.z);

        public static Vector3 WithSubtractY(this Vector3 v, float y) =>
            new Vector3(v.x, v.y - y, v.z);

        public static Vector3 WithMultiplyY(this Vector3 v, float y) =>
            new Vector3(v.x, v.y * y, v.z);

        #endregion

        #region Set Y

        public static Vector3 SetY(this ref Vector3 v, float y)
        {
            v = new Vector3(v.x, y, v.z);
            return v;
        }

        public static Vector3 SetY(this ref Vector3 v, Vector3 target)
        {
            v = new Vector3(v.x, target.y, v.z);
            return v;
        }

        public static Vector3 SetAddY(this ref Vector3 v, float y)
        {
            v = new Vector3(v.x, v.y + y, v.z);
            return v;
        }

        public static Vector3 SetSubtractY(this ref Vector3 v, float y)
        {
            v = new Vector3(v.x, v.y - y, v.z);
            return v;
        }

        public static Vector3 SetMultiplyY(this ref Vector3 v, float y)
        {
            v = new Vector3(v.x, v.y * y, v.z);
            return v;
        }

        #endregion

        #region with Z
        public static Vector3 WithZ(this Vector3 v, float z) => new Vector3(v.x, v.y, z);

        public static Vector3 WithPosZ(this Vector3 v, Transform target) =>
            new Vector3(v.x, v.y, target.position.z);

        public static Vector3 WithZ(this Vector3 v, Vector3 target) =>
            new Vector3(v.x, v.y, target.z);

        public static Vector3 WithAddZ(this Vector3 v, float z) => new Vector3(v.x, v.y, v.z + z);

        public static Vector3 WithSubtractZ(this Vector3 v, float z) =>
            new Vector3(v.x, v.y, v.z - z);

        public static Vector3 WithMultiplyZ(this Vector3 v, float z) =>
            new Vector3(v.x, v.y, v.z * z);

        #endregion


        #region Set Z

        public static Vector3 SetZ(this ref Vector3 v, float z)
        {
            v = new Vector3(v.x, v.y, z);
            return v;
        }

        public static Vector3 SetZ(this ref Vector3 v, Vector3 target)
        {
            v = new Vector3(v.x, v.y, target.z);
            return v;
        }

        public static Vector3 SetAddZ(this ref Vector3 v, float z)
        {
            v = new Vector3(v.x, v.y, v.z + z);
            return v;
        }

        public static Vector3 SetSubtractZ(this ref Vector3 v, float z)
        {
            v = new Vector3(v.x, v.y, v.z - z);
            return v;
        }

        public static Vector3 SetMultiplyZ(this ref Vector3 v, float z)
        {
            v = new Vector3(v.x, v.y, v.z * z);
            return v;
        }

        #endregion

        #region With XY, XZ, YZ

        public static Vector3 WithXY(this Vector3 v, float x, float y) => new Vector3(x, y, v.z);

        public static Vector3 WithXZ(this Vector3 v, float x, float z) => new Vector3(x, v.y, z);

        public static Vector3 WithYZ(this Vector3 v, float y, float z) => new Vector3(v.x, y, z);

        #endregion

        #region Set XY, XZ, YZ

        public static Vector3 SetXY(this ref Vector3 v, float x, float y)
        {
            v = new Vector3(x, y, v.z);
            return v;
        }

        public static Vector3 SetXZ(this ref Vector3 v, float x, float z)
        {
            v = new Vector3(x, v.y, z);
            return v;
        }

        public static Vector3 SetYZ(this ref Vector3 v, float y, float z)
        {
            v = new Vector3(v.x, y, z);
            return v;
        }

        #endregion

        #region Clamp

        public static Vector3 Clamp(this Vector3 value, Vector3 min, Vector3 max)
        {
            return new Vector3(
                Mathf.Clamp(value.x, min.x, max.x),
                Mathf.Clamp(value.y, min.y, max.y),
                Mathf.Clamp(value.z, min.z, max.z)
            );
        }

        public static Vector3 Clamp01(this Vector3 value)
        {
            return new Vector3(
                Mathf.Clamp01(value.x),
                Mathf.Clamp01(value.y),
                Mathf.Clamp01(value.z)
            );
        }

        public static Vector3 ClampMagnitude(this Vector3 vector, float maxLength) =>
            Vector3.ClampMagnitude(vector, maxLength);

        public static Vector3 Max(this Vector3 a, Vector3 b) =>
            new Vector3(Mathf.Max(a.x, b.x), Mathf.Max(a.y, b.y), Mathf.Max(a.z, b.z));

        public static Vector3 Min(this Vector3 a, Vector3 b) =>
            new Vector3(Mathf.Min(a.x, b.x), Mathf.Min(a.y, b.y), Mathf.Min(a.z, b.z));

        #endregion

        #region Lerp

        public static Vector3 Lerp(this Vector3 current, Vector3 target, float t) =>
            Vector3.Lerp(current, target, Mathf.Clamp01(t));

        public static Vector3 LerpUnclamped(this Vector3 current, Vector3 target, float t) =>
            Vector3.LerpUnclamped(current, target, t);

        public static Vector3 MoveTowards(this Vector3 current, Vector3 target, float maxDelta) =>
            Vector3.MoveTowards(current, target, maxDelta);

        #endregion

        #region Vector 2 conversion

        public static Vector2 ToVector2XY(this Vector3 v) => new Vector2(v.x, v.y);

        public static Vector2 ToVector2XZ(this Vector3 v) => new Vector2(v.x, v.z);

        public static Vector2 ToVector2YZ(this Vector3 v) => new Vector2(v.y, v.z);

        #endregion

        #region More

        public static Vector3 WithRandomBias(this Vector3 v, float biasValue) =>
            new Vector3(
                v.x.RandomBias(biasValue),
                v.y.RandomBias(biasValue),
                v.z.RandomBias(biasValue)
            );

        public static Vector3 WithRandomBias(this Vector3 v, Vector3 biasValue) =>
            new Vector3(
                v.x.RandomBias(biasValue.x),
                v.y.RandomBias(biasValue.y),
                v.z.RandomBias(biasValue.z)
            );

        public static Vector3 GetClosest(this Vector3 position, IEnumerable<Vector3> otherPositions)
        {
            var closest = Vector3.zero;
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

        public static bool IsClose(this Vector3 a, Vector3 b, float epsilon = Vector3.kEpsilon)
        {
            return (a - b).sqrMagnitude <= epsilon * epsilon;
        }

        public static Vector3 SetMagnitude(this Vector3 vector, float magnitude) =>
            vector.normalized * magnitude;

        public static Vector3 ScaleBy(this Vector3 v, Vector3 scale) =>
            new Vector3(v.x * scale.x, v.y * scale.y, v.z * scale.z);

        public static Vector3 ChangeIfInfinity(this Vector3 v, float valueToChangeTo = 0)
        {
            if (float.IsInfinity(v.x))
                v.x = valueToChangeTo;
            if (float.IsInfinity(v.y))
                v.y = valueToChangeTo;
            if (float.IsInfinity(v.z))
                v.z = valueToChangeTo;

            return v;
        }

        public static float Distance(this Vector3 v, Vector3 target) => Vector3.Distance(v, target);

        public static float Distance(this Vector3 v, Transform target) =>
            Vector3.Distance(v, target.position);

        public static float DistanceWithoutHeight(this Vector3 v, Vector3 target) =>
            Vector3.Distance(v.WithY(0), target.WithY(0));

        public static float DistanceOfHeight(this Vector3 v, Vector3 target) =>
            Vector3.Distance(v.WithX(0), target.WithY(0));
        #endregion

        public static Vector3 Remap(
            this Vector3 vector,
            Vector3 sourceMin,
            Vector3 sourceMax,
            Vector3 targetMin,
            Vector3 targetMax
        ) =>
            new Vector3(
                vector.x.Remap(sourceMin.x, sourceMax.x, targetMin.x, targetMax.x),
                vector.y.Remap(sourceMin.y, sourceMax.y, targetMin.y, targetMax.y),
                vector.z.Remap(sourceMin.z, sourceMax.z, targetMin.z, targetMax.z)
            );

        public static bool IsUniform(this Vector3 vector) =>
            vector.x.Approximately(vector.y) && vector.y.Approximately(vector.z);

        public static Vector3 Abs(this Vector3 vector) =>
            new(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));

        public static Vector3 Round(this Vector3 vector)
        {
            vector.x = Mathf.Round(vector.x);
            vector.y = Mathf.Round(vector.y);
            vector.z = Mathf.Round(vector.z);
            return vector;
        }

        /// <summary>
        /// Inverts a vector
        /// </summary>
        public static Vector3 Invert(this Vector3 newValue) =>
            new Vector3(1.0f / newValue.x, 1.0f / newValue.y, 1.0f / newValue.z);

        /// <summary>
        /// Projects a vector on another
        /// </summary>
        public static Vector3 Project(this Vector3 vector, Vector3 projectedVector)
        {
            float _dot = Vector3.Dot(vector, projectedVector);
            return _dot * projectedVector;
        }

        /// <summary>
        /// Rejects a vector on another
        /// </summary>
        public static Vector3 Reject(this Vector3 vector, Vector3 rejectedVector) =>
            vector - vector.Project(rejectedVector);

        #region Swap

        public static Vector3 SwapXY(this Vector3 vector) =>
            new Vector3(vector.y, vector.x, vector.z);

        public static Vector3 SwapYZ(this Vector3 vector) =>
            new Vector3(vector.x, vector.z, vector.y);

        public static Vector3 SwapXZ(this Vector3 vector) =>
            new Vector3(vector.z, vector.y, vector.x);

        #endregion
    }
}
