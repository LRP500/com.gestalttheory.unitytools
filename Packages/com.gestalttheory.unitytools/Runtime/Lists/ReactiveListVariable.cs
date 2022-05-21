using System.Collections.Generic;
using System.Linq;
using Sirenix.Utilities;
using UniRx;
using UnityEngine;

namespace UnityTools.Runtime.Lists
{
    public abstract class ReactiveListVariable<T> : ScriptableObject
    {
        private readonly ReactiveCollection<T> _values = new();
        public IReadOnlyReactiveCollection<T> Values => _values;

        public int Count => _values.Count();
        
        public virtual void Add(T entity)
        {
            _values.Add(entity);
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            _values.AddRange(entities);
        }
        
        public virtual void Remove(T entity)
        {
            _values.Remove(entity);
        }
        
        public virtual void Clear()
        {
            _values.Clear();
        }
    }
}