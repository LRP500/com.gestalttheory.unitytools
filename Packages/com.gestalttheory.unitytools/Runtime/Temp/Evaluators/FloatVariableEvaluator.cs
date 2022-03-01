﻿using UnityEngine;

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
            var evaluator = new NumericalEvaluator<float>();
            return evaluator.Evaluate(_target, _evaluation, _value);
        }
    }
}
