using UnityEngine;

namespace UnityTools.Runtime.Variables
{
    public abstract class VariableEvaluator : ScriptableObject
    {
        public abstract bool Evaluate();
    }
}
