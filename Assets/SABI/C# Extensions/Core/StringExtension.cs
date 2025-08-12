using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace SABI
{
    public static class StringExtension
    {
        public static T ToEnum<T>(this string str)
            where T : struct, Enum
        {
            if (Enum.TryParse<T>(str, true, out var result))
                return result;

            throw new ArgumentException($"Cannot convert '{str}' to enum {typeof(T).Name}");
        }

        public static string Truncate(this string str, int maxLength)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return str.Length <= maxLength ? str : str.Substring(0, maxLength);
        }

        public static string ToTitleCase(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }

        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

        public static bool IsNullOrWhiteSpace(this string str) => string.IsNullOrWhiteSpace(str);

        public static string Reverse(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public static string RemoveWhitespace(this string str) =>
            new string(str.Where(c => !char.IsWhiteSpace(c)).ToArray());

        public static string ToCamelCase(this string str)
        {
            if (string.IsNullOrEmpty(str) || !char.IsUpper(str[0]))
                return str;

            string camelCase = char.ToLower(str[0]).ToString();
            if (str.Length > 1)
                camelCase += str.Substring(1);
            return camelCase;
        }

        public static string SplitCamelCase(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return Regex.Replace(str, "([a-z])([A-Z])", "$1 $2");
        }
    }
}
