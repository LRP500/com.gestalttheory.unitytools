using UnityEngine;
using UnityTools.Runtime.Math.Operations;

namespace UnityTools.Runtime.Variables
{
    [System.Serializable]
    public class IntVariableModifier : VariableModifier
    {
        [SerializeField]
        private IntVariable _variable;

        [SerializeField]
        private NumericalOperator _operator;

        [SerializeField]
        private int _value;

        public override void Modify()
        {
            var value = _variable.Value.Modify(_operator, _value);
            _variable.SetValue(value);
        }
    }
}
