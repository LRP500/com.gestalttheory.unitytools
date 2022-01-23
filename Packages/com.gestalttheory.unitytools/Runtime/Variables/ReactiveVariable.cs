using UniRx;
using UnityEngine;

namespace UnityTools.Runtime.Variables
{
    public abstract class ReactiveVariable<T> : ScriptableObject
    {
        public ReactiveProperty<T> Value { get; private set; } = new();
    }
}
