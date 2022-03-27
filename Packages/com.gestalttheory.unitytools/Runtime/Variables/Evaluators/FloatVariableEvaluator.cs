using UnityEngine;
using UnityTools.Runtime.Math;

namespace UnityTools.Runtime.Variables
{
    [System.Serializable]
    public class FloatVariableEvaluator : VariableEvaluator
    {
        [SerializeField]
        private FloatVariable _target;

        [SerializeField]
        private NumericalEvaluation _evaluation;

        [SerializeField]
        private float _value;

        public override bool Evaluate()
        {
            return _target.Value.Evaluate(_evaluation, _value);
        }
    }
}
