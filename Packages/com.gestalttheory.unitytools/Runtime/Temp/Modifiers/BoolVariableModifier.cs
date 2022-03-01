using UnityEngine;

namespace UnityTools.Runtime.Variables
{
    [System.Serializable]
    public class BoolVariableModifier : VariableModifier
    {
        [SerializeField]
        private BoolVariable _variable;

        [SerializeField]
        private BooleanOperator _type;

        [SerializeField]
        private bool _value;

        public override void Modify()
        {
            switch (_type)
            {
                case BooleanOperator.Set:
                    _variable.SetValue(_value); break;
                case BooleanOperator.And:
                    _variable.SetValue(_variable.Value && _value); break;
                case BooleanOperator.Or:
                    _variable.SetValue(_variable.Value || _value); break;
                case BooleanOperator.Not:
                    _variable.SetValue(!_variable.Value); break;
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }
    }
}
