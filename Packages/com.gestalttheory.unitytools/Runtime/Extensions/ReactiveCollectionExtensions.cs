using System.Collections.Generic;
using UniRx;

namespace Extensions
{
    public static class ReactiveCollectionExtensions
    {
        public static void AddRange<T>(this ReactiveCollection<T> collection, IEnumerable<T> items)
        {
            foreach (var obj in items)
            {
                collection.Add(obj);
            }
        }
    }
}