using UnityEngine;

namespace SABI
{
    public static class Vector2Extensions
    {
        public static Vector2 SetValue(this Vector2 v, float value) => new Vector2(value, value);

        public static Vector2 WithX(this Vector2 vector, float x) => new Vector2(x, vector.y);

        public static Vector2 WithY(this Vector2 vector, float y) => new Vector2(vector.x, y);

        public static Vector2 SetMagnitude(this Vector2 vector, float magnitude) =>
            vector.normalized * magnitude;

        public static Vector2 WithAddX(this Vector2 v, float x) => new Vector2(v.x + x, v.y);

        public static Vector2 WithSubtractX(this Vector2 v, float x) => new Vector2(v.x - x, v.y);

        public static Vector2 WithMultiplyX(this Vector2 v, float x) => new Vector2(v.x * x, v.y);

        public static Vector2 WithAddY(this Vector2 v, float y) => new Vector2(v.x, v.y + y);

        public static Vector2 WithSubtractY(this Vector2 v, float y) => new Vector2(v.x, v.y - y);

        public static Vector2 WithMultiplyY(this Vector2 v, float y) => new Vector2(v.x, v.y * y);

        public static Vector2 Clamp(this Vector2 value, Vector2 min, Vector2 max) =>
            new Vector2(Mathf.Clamp(value.x, min.x, max.x), Mathf.Clamp(value.y, min.y, max.y));

        public static Vector2 Clamp01(this Vector2 value) =>
            new Vector2(Mathf.Clamp01(value.x), Mathf.Clamp01(value.y));

        public static Vector2 ClampMagnitude(this Vector2 vector, float maxLength) =>
            Vector2.ClampMagnitude(vector, maxLength);

        public static Vector2 Lerp(this Vector2 current, Vector2 target, float t) =>
            Vector2.Lerp(current, target, Mathf.Clamp01(t));

        public static Vector2 LerpUnclamped(this Vector2 current, Vector2 target, float t) =>
            Vector2.LerpUnclamped(current, target, t);

        public static Vector2 MoveTowards(this Vector2 current, Vector2 target, float maxDelta) =>
            Vector2.MoveTowards(current, target, maxDelta);

        public static Vector2 Max(this Vector2 a, Vector2 b) =>
            new Vector2(Mathf.Max(a.x, b.x), Mathf.Max(a.y, b.y));

        public static Vector2 Min(this Vector2 a, Vector2 b) =>
            new Vector2(Mathf.Min(a.x, b.x), Mathf.Min(a.y, b.y));

        public static Vector2 WithRandomBias(this Vector2 v, float biasValue) =>
            new Vector2(v.x.RandomBias(biasValue), v.y.RandomBias(biasValue));

        public static Vector2 WithRandomBias(this Vector2 v, Vector2 biasValue) =>
            new Vector2(v.x.RandomBias(biasValue.x), v.y.RandomBias(biasValue.y));

        public static Vector2 Remap(
            this Vector2 vector,
            Vector2 sourceMinMax, // [sourceMin, sourceMax]
            Vector2 targetMinMax // [targetMin, targetMax]
        ) =>
            new Vector2(
                vector.x.Remap(sourceMinMax.x, sourceMinMax.y, targetMinMax.x, targetMinMax.y),
                vector.y.Remap(sourceMinMax.x, sourceMinMax.y, targetMinMax.x, targetMinMax.y)
            );

        public static bool IsUniform(this Vector2 vector) => vector.x.Approximately(vector.y);

        public static Vector2 Abs(this Vector2 vector) =>
            new(Mathf.Abs(vector.x), Mathf.Abs(vector.y));

        public static Vector2 Round(this Vector2 vector)
        {
            vector.x = Mathf.Round(vector.x);
            vector.y = Mathf.Round(vector.y);
            return vector;
        }

        /// <summary>
        /// Rotates a vector2 by angleInDegrees
        /// </summary>
        public static Vector2 Rotate(this Vector2 vector, float angleInDegrees)
        {
            float sin = Mathf.Sin(angleInDegrees * Mathf.Deg2Rad);
            float cos = Mathf.Cos(angleInDegrees * Mathf.Deg2Rad);
            float tx = vector.x;
            float ty = vector.y;
            vector.x = (cos * tx) - (sin * ty);
            vector.y = (sin * tx) + (cos * ty);
            return vector;
        }
    }
}
