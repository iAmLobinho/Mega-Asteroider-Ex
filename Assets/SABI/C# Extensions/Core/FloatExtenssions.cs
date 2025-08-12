using System;
using UnityEngine;

namespace SABI
{
    public static class FloatExtenssions
    {
        public static float RandomBias(
            this float value,
            float range,
            bool useNegativeBias = true
        ) => (value + (value * UnityEngine.Random.Range(useNegativeBias ? -range : 0, range)));

        public static float Round(this float value, int digits = 0) =>
            (float)Math.Round(value, digits);

        public static bool IsApproximatelyEqual(
            this float value,
            float other,
            float tolerance = 0.0001f
        ) => Math.Abs(value - other) < tolerance;

        public static float ToPercentage(this float value, float total) => (value / total) * 100f;

        public static bool IsInRange(this float value, float minValue, float maxValue) =>
            value >= minValue && value <= maxValue;

        public static float ClosestInRange(this float value, float minValue, float maxValue)
        {
            if (value.IsInRange(minValue, maxValue))
                return value;

            float diffrenceToMinValue = Mathf.Abs(value - minValue);
            float diffrenceToMaxValue = Mathf.Abs(value - maxValue);

            return MathF.Min(diffrenceToMinValue, diffrenceToMaxValue);
        }

        public static float Max(this float value, float max) => value <= max ? value : max;

        public static float Min(this float value, float min) => value <= min ? min : value;

        public static float Clamp(this float value, float min, float max) =>
            Mathf.Clamp(value, min, max);

        public static float Lerp(this float current, float target, float t) =>
            Mathf.Lerp(current, target, Mathf.Clamp01(t));

        public static float LerpUnclamped(this float current, float target, float t) =>
            Mathf.LerpUnclamped(current, target, t);

        public static float MoveTowards(this float current, float target, float maxDelta) =>
            Mathf.MoveTowards(current, target, maxDelta);

        /// <summary>
        /// Remap a value from source range to targetRange.
        /// </summary>
        public static float Remap(
            this float value,
            float min1,
            float max1,
            float min2,
            float max2
        ) => min2 + (value - min1) * (max2 - min2) / (max1 - min1);

        public static bool Approximately(this float value, float other) =>
            Mathf.Approximately(value, other);
    }
}
