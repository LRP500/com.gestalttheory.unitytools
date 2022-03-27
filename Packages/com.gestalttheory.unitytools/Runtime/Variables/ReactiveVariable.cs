using UniRx;
using UnityEngine;

namespace UnityTools.Runtime.Variables
{
    public abstract class ReactiveVariable<T> : ScriptableObject
    {
        private readonly ReactiveProperty<T> _property = new();
        public IReadOnlyReactiveProperty<T> Property => _property;

        public void SetValue(T value, bool forceNotify = false)
        {
            if (forceNotify)
            {
                _property.SetValueAndForceNotify(value);
                return;
            }

            _property.Value = value;
        }
        
        public void Clear()
        {
            SetValue(default);
        }
    }
}
