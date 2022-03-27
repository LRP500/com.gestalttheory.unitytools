using UnityEngine;
using UnityTools.Runtime.Math.Operations;

namespace UnityTools.Runtime.Variables
{
    [System.Serializable]
    public class FloatVariableModifier : VariableModifier
    {
        [SerializeField]
        private FloatVariable _variable;

        [SerializeField]
        private NumericalOperator _operator;
        
        [SerializeField]
        private float _value;

        public override void Modify()
        {
            float value = _variable.Value.Modify(_operator, _value);   
            _variable.SetValue(value);
        }
    }
}
