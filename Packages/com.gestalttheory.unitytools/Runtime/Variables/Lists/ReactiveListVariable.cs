using System.Collections.Generic;
using Extensions;
using UniRx;
using UnityEngine;

namespace UnityTools.Runtime.Lists
{
    public abstract class ReactiveListVariable : ScriptableObject
    {
        public abstract int Count { get; }
    }
    
    public abstract class ReactiveListVariable<T> : ReactiveListVariable
    {
        public ReactiveCollection<T> Values { get; } = new();
        public override int Count => Values.Count;

        public void SetValues(IEnumerable<T> values)
        {
            Values.Clear();
            Values.AddRange(values);
        }
    }
}