using System;
using UniRx;
using UnityEngine;

namespace UnityTools.Runtime.Variables
{
    public abstract class ReactiveVariable<T> : ScriptableObject
    {
        [InspectorDisplay]
        private readonly ReactiveProperty<T> _property = new();
        
        public IReadOnlyReactiveProperty<T> Property => _property;

        public T Value => _property.Value;
        
        public void SetValue(T value, bool forceNotify)
        {
            if (forceNotify)
            {
                _property.SetValueAndForceNotify(value);
                return;
            }

            SetValue(value);
        }
        
        public void SetValue(T value)
        {
            _property.Value = value;
        }
        
        public void Clear()
        {
            SetValue(default);
        }

        public IObservable<T> ObserveValueChanged()
        {
            return Property;
        }
    }
}
