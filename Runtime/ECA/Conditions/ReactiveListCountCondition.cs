using UnityEngine;
using UnityTools.Runtime.Lists;
using UnityTools.Runtime.Math;

namespace UnityTools.Runtime.ECA.Conditions
{
    [CreateAssetMenu(menuName = ContextMenuPath.Conditions + "Reactive List Count")]
    public class ReactiveListCountCondition : ScriptableCondition
    {
        [SerializeField]
        private ReactiveListVariable _props;

        [SerializeField]
        private NumericalEvaluation _operator;

        [SerializeField]
        private int _value;
        
        public override bool Evaluate()
        {
            return _props.Count.Evaluate(_operator, _value);
        }
    }
}