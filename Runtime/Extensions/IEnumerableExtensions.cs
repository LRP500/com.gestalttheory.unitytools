using System.Collections.Generic;
using System.Linq;

namespace UnityTools.Runtime.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            var items = source.ToList();
            items.Shuffle();
            return items;
        }
    }
}