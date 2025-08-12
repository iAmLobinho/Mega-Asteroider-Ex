using System.Collections.Generic;

namespace SABI
{
    public static class DictionaryExtensions
    {
        public static Dictionary<TKey, TValue> AddOrUpdate<TKey, TValue>(
            this Dictionary<TKey, TValue> dictionary,
            TKey key,
            TValue value
        )
        {
            if (dictionary.ContainsKey(key))
                dictionary[key] = value;
            else
                dictionary.Add(key, value);

            return dictionary;
        }

        public static TKey GetKeyByValue<TKey, TValue>(
            this Dictionary<TKey, TValue> dictionary,
            TKey value
        )
        {
            TKey key = default;
            foreach (KeyValuePair<TKey, TValue> pair in dictionary)
            {
                if (pair.Value.Equals(value))
                {
                    key = pair.Key;
                    break;
                }
            }
            return key;
        }

        public static bool ContainsAndNotNull<TKey, TValue>(
            this Dictionary<TKey, TValue> dictionary,
            TKey key
        )
            where TValue : UnityEngine.Object =>
            dictionary.ContainsKey(key) && dictionary[key] != null;
    }
}
