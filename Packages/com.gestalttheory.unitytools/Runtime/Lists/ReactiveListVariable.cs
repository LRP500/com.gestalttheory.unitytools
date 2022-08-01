using System.Collections.Generic;
using Extensions;
using UniRx;
using UnityEngine;

namespace UnityTools.Runtime.Lists
{
    public abstract class ReactiveListVariable<T> : ScriptableObject
    {
        public ReactiveCollection<T> Values { get; }= new();

        public void SetValues(IEnumerable<T> values)
        {
            Values.Clear();
            Values.AddRange(values);
        }
    }
}