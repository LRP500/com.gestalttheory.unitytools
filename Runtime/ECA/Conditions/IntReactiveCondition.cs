using UnityEngine;
using UnityTools.Runtime.Math;
using UnityTools.Runtime.Variables;

namespace UnityTools.Runtime.ECA.Conditions
{
    [CreateAssetMenu(menuName = ContextMenuPath.Conditions + "Evaluate Int Reactive")]
    public class IntReactiveCondition : ScriptableCondition
    {
        [SerializeField]
        private IntReactiveVariable _variable;

        [SerializeField]
        private NumericalEvaluation _evaluation;

        [SerializeField]
        private int _value;
        
        public override bool Evaluate()
        {
            return _variable.Value.Evaluate(_evaluation, _value);
        }
    }
}