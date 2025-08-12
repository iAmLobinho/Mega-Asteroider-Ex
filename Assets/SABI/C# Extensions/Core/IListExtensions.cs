using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace SABI
{
    public static class IListExtensions
    {
        /// <summary>
        /// Checks if the list is null or contains no elements
        /// </summary>
        public static bool IsNullOrEmpty<T>(this IList<T> list) => list == null || list.Count == 0;

        /// <summary>
        /// Returns a random item from the list
        /// </summary>
        public static T GetRandomItem<T>(this IList<T> _array)
        {
            if (_array == null)
                throw new System.IndexOutOfRangeException(
                    " [ array is null ] Cannot select a random item from null"
                );
            if (_array.Count == 0)
                throw new System.IndexOutOfRangeException(
                    " [ array is empty ] Cannot select a random item from an empty array"
                );
            return _array[Random.Range(0, _array.Count)];
        }

        /// <summary>
        /// Returns a specified number of random items from the list without duplicates
        /// </summary>
        public static List<T> GetUniqeRandomItems<T>(this IList<T> list, int count)
        {
            if (count > list.Count)
                throw new System.ArgumentException("Requested count is larger than list size");

            List<T> result = new List<T>();
            List<T> tempList = new List<T>(list);
            for (int i = 0; i < count; i++)
            {
                int index = Random.Range(0, tempList.Count);
                result.Add(tempList[index]);
                tempList.RemoveAt(index);
            }
            return result;
        }

        /// <summary>
        /// Removes all null elements from the list
        /// </summary>
        public static IList<T> RemoveNulls<T>(this List<T> list)
            where T : class
        {
            list.RemoveAll(item => item == null);
            return list;
        }

        /// <summary>
        /// Randomly reorders the elements in the list using the Fisher-Yates shuffle algorithm
        /// </summary>
        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Range(0, n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

        /// <summary>
        /// Gets a random item based on weights (useful for probability-based selections)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="weights"></param>
        /// <returns></returns>
        public static T GetWeightedRandom<T>(this IList<T> list, IList<float> weights)
        {
            float totalWeight = 0;
            foreach (float weight in weights)
                totalWeight += weight;

            float random = UnityEngine.Random.Range(0, totalWeight);
            float current = 0;

            for (int i = 0; i < list.Count; i++)
            {
                current += weights[i];
                if (random <= current)
                    return list[i];
            }

            return list[list.Count - 1];
        }

        public static IList<T> ForEach<T>(this IList<T> list, System.Action<T, int> action)
        {
            for (int i = 0; i < list.Count; i++)
                action?.Invoke(list[i], i);
            return list;
        }

        public static IList<T> ForEach<T>(this IList<T> list, System.Action<T> action)
        {
            for (int i = 0; i < list.Count; i++)
                action?.Invoke(list[i]);
            return list;
        }

        /// <summary>
        /// Moves an item from one index to another
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="oldIndex"></param>
        /// <param name="newIndex"></param>
        public static IList<T> Move<T>(this IList<T> list, int oldIndex, int newIndex)
        {
            if (oldIndex == newIndex)
                return list;

            T item = list[oldIndex];
            list.RemoveAt(oldIndex);
            list.Insert(newIndex, item);
            return list;
        }

        /// <summary>
        /// Swaps two items in the list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="index1"></param>
        /// <param name="index2"></param>
        public static IList<T> Swap<T>(this IList<T> list, int index1, int index2)
        {
            if (index1 == index2)
                return list;
            ;

            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
            return list;
        }

        /// <summary>
        /// Replaces the first occurrence of an item with another
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="oldItem"></param>
        /// <param name="newItem"></param>
        /// <returns></returns>
        public static IList<T> Replace<T>(this IList<T> list, T oldItem, T newItem)
        {
            int index = list.IndexOf(oldItem);
            list[index] = newItem;
            return list;
        }

        /// <summary>
        /// Removes duplicate items from the list while preserving order
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public static IList<T> RemoveDuplicates<T>(this IList<T> list)
        {
            HashSet<T> seen = new HashSet<T>();
            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (!seen.Add(list[i]))
                    list.RemoveAt(i);
            }
            return list;
        }

        /// <summary>
        /// Pops element by <paramref name="index"/>.
        /// </summary>
        public static T Pop<T>(this IList<T> list, int? index = null)
        {
            if (index == null)
                index = list.Count - 1;
            var element = list[index.Value];
            list.RemoveAt(index.Value);

            return element;
        }

        /// <summary>
        /// Pops elements by <paramref name="indexes"/>.
        /// </summary>
        public static List<T> PopList<T>(this IList<T> list, params int[] indexes)
        {
            var popped = new List<T>();

            foreach (var index in indexes)
                popped.Add(list.Pop(index));

            return popped;
        }

        /// <summary>
        /// Pops random element from <paramref name="list"/>.
        /// </summary>
        public static T PopRandom<T>(this IList<T> list)
        {
            var index = UnityEngine.Random.Range(0, list.Count);
            return list.Pop(index);
        }

        /// <summary>
        /// Pops random element from <paramref name="list"/>.
        /// </summary>
        public static (T element, int index) PopRandomTuple<T>(this IList<T> list)
        {
            var index = UnityEngine.Random.Range(0, list.Count);
            return (list.Pop(index), index);
        }

        /// <summary>
        /// Pops random elements from list.
        /// </summary>
        public static List<T> PopRandoms<T>(this IList<T> list, int count)
        {
            var popped = new List<T>();

            for (int i = 0; i < count; i++)
                popped.Add(list.PopRandom());

            return popped;
        }

        /// <summary>
        /// Pops random elements from list.
        /// </summary>
        public static List<(T element, int index)> PopRandomsTupleList<T>(
            this IList<T> list,
            int count
        )
        {
            var popped = new List<(T element, int index)>();

            for (int i = 0; i < count; i++)
                popped.Add(list.PopRandomTuple());

            return popped;
        }

        public static IList<T> RemoveRange<T>(this IList<T> list, int index)
        {
            for (int i = list.Count - 1; i >= index; i++)
                list.RemoveAt(i);
            return list;
        }
    }
}
