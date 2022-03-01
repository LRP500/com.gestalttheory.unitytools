using UniRx;
using UnityEngine;

namespace UnityTools.Runtime.Lists
{
    public abstract class ReactiveScriptableList<T> : ScriptableObject
    {
        private readonly ReactiveCollection<T> _values = new();
        public IReadOnlyReactiveCollection<T> Values => _values;

        public virtual void Add(T entity)
        {
            _values.Add(entity);
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