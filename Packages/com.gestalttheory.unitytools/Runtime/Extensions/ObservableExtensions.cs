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

        public static IObservable<T> TakeFirst<T>(this IObservable<T> source)
        {
            return source.Take(1);
        }
        
        public static IObservable<bool> WhereTrue(this IObservable<bool> source)
        {
            return source.Where(x => x.Equals(true));
        }
        
        public static IObservable<bool> WhereFalse(this IObservable<bool> source)
        {
            return source.Where(x => x.Equals(false));
        }

        public static IObservable<T> WhereNull<T>(this IObservable<T> source)
        {
            return source.Where(x => x == null);
        }
        
        public static IObservable<T> WhereNotNull<T>(this IObservable<T> source)
        {
            return source.Where(x => x != null);
        }
        
        public static IDisposable SubscribeTwoStates(this IObservable<bool> source, Action onTrue, Action onFalse)
        {
            return source.Subscribe(x =>
            {
                var action = x ? onTrue : onFalse;
                action?.Invoke();
            });
        }
    }
}