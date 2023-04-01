using UnityEngine;
using UnityTools.Runtime.Math;

namespace UnityTools.Runtime.Variables
{
    [System.Serializable]
    public class IntVariableEvaluator : VariableEvaluator
    {
        [SerializeField]
        private IntVariable _target;

        [SerializeField]
        private NumericalEvaluation _evaluation;

        [SerializeField]
        private int _value;

        public override bool Evaluate()
        {
            return _target.Value.Evaluate(_evaluation, _value);
        }
    }
}
