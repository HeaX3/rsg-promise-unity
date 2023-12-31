using System;
using System.Collections.Generic;
using UnityEngine;

namespace RSG.Promises
{
    /// <summary>
    /// General extensions to LINQ.
    /// </summary>
    public static class EnumerableExt
    {
        [HideInCallstack]
        public static void Each<T>(this IEnumerable<T> source, Action<T> fn)
        {
            foreach (var item in source)
            {
                fn.Invoke(item);
            }
        }

        [HideInCallstack]
        public static void Each<T>(this IEnumerable<T> source, Action<T, int> fn)
        {
            int index = 0;

            foreach (T item in source)
            {
                fn.Invoke(item, index);
                index++;
            }
        }

        /// <summary>
        /// Convert a variable length argument list of items to an enumerable.
        /// </summary>
        [HideInCallstack]
        public static IEnumerable<T> FromItems<T>(params T[] items)
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }
    }
}
