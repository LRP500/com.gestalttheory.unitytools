using UnityEngine;

namespace Tools.Variables
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