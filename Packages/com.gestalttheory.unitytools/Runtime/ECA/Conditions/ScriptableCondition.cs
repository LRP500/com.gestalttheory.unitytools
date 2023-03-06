using UnityEngine;

namespace UnityTools.Runtime.ECA.Conditions
{
    public abstract class ScriptableCondition : ScriptableObject
    {
        public abstract bool Evaluate();
    }
}