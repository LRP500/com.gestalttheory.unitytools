using UnityEngine;

namespace UnityTools.Runtime.Variables
{
    [CreateAssetMenu(menuName = ContextMenuPath.VariableEvaluators + "/Bool")]
    public class BoolVariableEvaluator : VariableEvaluator
    {
        [SerializeField]
        private BoolVariable _target;

        [SerializeField]
        private BooleanEvaluation _evaluation;

        [SerializeField]
        private bool _value;

        public override bool Evaluate()
        {
            return _target.Value.Evaluate(_evaluation, _value);
        }
    }
}