using UniRx;
using UnityEngine;

namespace Tools.Variables
{
    public abstract class ReactiveVariable<T> : ScriptableObject
    {
        public ReactiveProperty<T> Value { get; private set; } = new();
    }
}
