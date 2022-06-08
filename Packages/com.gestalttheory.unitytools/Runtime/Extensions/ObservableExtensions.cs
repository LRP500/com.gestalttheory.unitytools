using System;
using System.Collections;
using System.Threading;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

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

        public static IObservable<bool> OnToggleOn(this Toggle toggle)
        {
            return Observable.CreateWithState<bool, Toggle>(toggle, (t, observer) => t.onValueChanged
                .AsObservable()
                .WhereTrue()
                .Subscribe(observer));
        }
        
        #region AsyncOperation

        public static IObservable<float> ToObservable(this AsyncOperation asyncOperation)
        {
            if (asyncOperation == null) throw new ArgumentNullException(nameof(asyncOperation));
            
            return Observable.FromCoroutine<float>((observer, cancellationToken) => 
                RunAsyncOperation(asyncOperation, observer, cancellationToken));
        }
        
        private static IEnumerator RunAsyncOperation(
            AsyncOperation asyncOperation,
            IObserver<float> observer,
            CancellationToken cancellationToken)
        {
            while (!asyncOperation.isDone && !cancellationToken.IsCancellationRequested)
            {
                observer.OnNext(asyncOperation.progress);
                yield return null;
            }

            if (cancellationToken.IsCancellationRequested)
                yield break;
            
            observer.OnNext(asyncOperation.progress);
            observer.OnCompleted();
        }

        #endregion AsyncOperation
    }
}