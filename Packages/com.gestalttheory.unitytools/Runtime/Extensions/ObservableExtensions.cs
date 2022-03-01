using System;
using UniRx;

namespace UnityTools.Runtime.Extensions
{
    public static class ObservableExtensions
    {
        public static IObservable<T> SkipFirst<T>(this IObservable<T> source)
        {
            return source.Skip(1);
        }

        public static IObservable<bool> WhereTrue(this IObservable<bool> source)
        {
            return source.Where(x => x.Equals(true));
        }
        
        public static IObservable<bool> WhereFalse(this IObservable<bool> source)
        {
            return source.Where(x => x.Equals(false));
        }
    }
}