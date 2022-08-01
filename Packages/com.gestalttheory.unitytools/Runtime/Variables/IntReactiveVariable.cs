﻿using UnityEngine;

namespace UnityTools.Runtime.Variables
{
    [CreateAssetMenu(menuName = ContextMenuPath.ReactiveVariables + "Int")]
    public class IntReactiveVariable : ReactiveVariable<int>
    {
        public void Increment()
        {
            SetValue(Value + 1);
        }

        public void Decrement()
        {
            SetValue(Value - 1);
        }
    }
}