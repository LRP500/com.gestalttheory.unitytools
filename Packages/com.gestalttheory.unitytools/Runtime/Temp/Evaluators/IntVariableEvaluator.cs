using UnityEngine;

namespace UnityTools.Runtime.Variables
{
    [CreateAssetMenu(menuName = ContextMenuPath.VariableEvaluators + "/Int")]
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
            var evaluator = new NumericalEvaluator<int>();
            return evaluator.Evaluate(_target, _evaluation, _value);
        }
    }
}
