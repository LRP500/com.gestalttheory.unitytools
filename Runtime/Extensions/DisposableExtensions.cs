using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace UnityTools.Runtime.Extensions
{
    public static class DisposableExtensions
    {
        public static void AddToDisable(this IDisposable source, Component target)
        {
            source.AddTo(target.gameObject);
            target.OnDisableAsObservable()
                .First()
                .Subscribe(_ => source.Dispose());
        }
        
        public static void Clear(this SerialDisposable source)
        {
            source.Disposable = null;
        }
    }
}