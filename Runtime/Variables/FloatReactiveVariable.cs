using UnityEngine;

namespace UnityTools.Runtime.Variables
{
    [CreateAssetMenu(menuName = ContextMenuPath.ReactiveVariables + "Float")]
    public class FloatReactiveVariable : ReactiveVariable<float>
    {
        public void Add(float value)
        {
            SetValue(Value + value);
        }

        public void Subtract(float value)
        {
            SetValue(Value - value);
        }
    }
}