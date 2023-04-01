using UnityEngine;
using UnityTools.Runtime.Math;
using UnityTools.Runtime.Variables;

namespace UnityTools.Runtime.ECA.Conditions
{
    [CreateAssetMenu(menuName = ContextMenuPath.Conditions + "Evaluate Bool Reactive")]
    public class BoolReactiveCondition : ScriptableCondition
    {
        [SerializeField]
        private BoolReactiveVariable _variable;

        [SerializeField]
        private BooleanEvaluation _evaluation;

        [SerializeField]
        private bool _value;
        
        public override bool Evaluate()
        {
            return _variable.Value.Evaluate(_evaluation, _value);
        }
    }
}