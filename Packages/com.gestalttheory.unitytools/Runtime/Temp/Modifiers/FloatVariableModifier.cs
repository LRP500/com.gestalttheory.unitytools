using UnityEngine;

namespace UnityTools.Runtime.Variables
{
    [CreateAssetMenu(menuName = ContextMenuPath.VariableModifiers + "/Float")]
    public class FloatVariableModifier : VariableModifier
    {
        [SerializeField]
        private FloatVariable _variable;

        [SerializeField]
        private float _value;

        public override void Modify()
        {
            _variable.SetValue(_value);
        }
    }
}
