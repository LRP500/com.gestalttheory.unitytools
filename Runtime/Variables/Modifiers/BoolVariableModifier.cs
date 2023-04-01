using UnityEngine;
using UnityTools.Runtime.Math.Operations;

namespace UnityTools.Runtime.Variables
{
    [System.Serializable]
    public class BoolVariableModifier : VariableModifier
    {
        [SerializeField]
        private BoolVariable _variable;

        [SerializeField]
        private BooleanOperator _operator;

        [SerializeField]
        private bool _value;

        public override void Modify()
        {
            bool value = _variable.Value.Modify(_operator, _value);
            _variable.SetValue(value);
        }
    }
}
