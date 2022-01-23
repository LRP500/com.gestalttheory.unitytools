using UnityEngine;

namespace UnityTools.Runtime.Variables
{
    public abstract class Variable<T> : ScriptableObject
    {
        public T Value { get; private set; }

        public void SetValue(T value)
        {
            Value = value;
        }
    }
}