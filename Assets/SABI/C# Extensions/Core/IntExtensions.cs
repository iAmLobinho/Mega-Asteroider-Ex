using System;
using UnityEngine;

namespace SABI
{
    public static class IntExtensions
    {
        public static string ToAbbreviatedString(this int n, uint digits = 0)
        {
            string s;
            var nabs = Math.Abs(n);
            if (nabs < 1000)
                s = n + "";
            else if (nabs < 1000000)
                s = ((decimal)n / 1000).TruncateTo(digits) + "k";
            else if (nabs < 1000000000)
                s = ((decimal)n / 1000000).TruncateTo(digits) + "m";
            else
                s = ((decimal)n / 1000000000).TruncateTo(digits) + "g";

            return s;
        }

        public static int RoundToMultipleOf(this int n, int binSize)
        {
            var result = (n / binSize) * binSize;
            if (n < 0)
            {
                result -= binSize;
            }
            return result;
        }

        public static bool IsInRange(this int value, int minValue, int maxValue) =>
            value >= minValue && value <= maxValue;

        public static int ClosestInRange(this int value, int minValue, int maxValue)
        {
            if (value.IsInRange(minValue, maxValue))
                return value;

            int diffrenceToMinValue = Mathf.Abs(value - minValue);
            int diffrenceToMaxValue = Mathf.Abs(value - maxValue);

            return (int)MathF.Min(diffrenceToMinValue, diffrenceToMaxValue);
        }

        public static int Max(this int value, int max) => value <= max ? value : max;

        public static int Min(this int value, int min) => value <= min ? min : value;

        public static int Clamp(this int value, int min, int max) =>
            Math.Max(min, Math.Min(max, value));

        public static int Lerp(this int current, int target, float t)
        {
            t = Mathf.Clamp01(t);
            return Mathf.RoundToInt(Mathf.Lerp(current, target, t));
        }

        public static int LerpUnclamped(this int current, int target, float t) =>
            Mathf.RoundToInt(Mathf.LerpUnclamped(current, target, t));

        public static int MoveTowards(this int current, int target, int maxDelta)
        {
            if (Mathf.Abs(target - current) <= maxDelta)
                return target;

            return current + (int)Mathf.Sign(target - current) * maxDelta;
        }

        /// <summary>
        /// Remap a value from source range to targetRange.
        /// </summary>
        public static int Remap(this int value, Vector2Int sourceRange, Vector2Int targetRange)
        {
            if (sourceRange.x == sourceRange.y)
                return targetRange.x; // Avoid division by zero
            float t = (value - sourceRange.x) / (float)(sourceRange.y - sourceRange.x);
            return Mathf.RoundToInt(Mathf.Lerp(targetRange.x, targetRange.y, t));
        }
    }
}
