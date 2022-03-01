namespace UnityTools.Runtime.Variables
{
    public enum NumericalOperator
    {
        AddValue,
        AddPercentage,
        SetEqualTo,
        MultiplyBy,
        DivideBy
    }

    public enum BooleanOperator
    {
        Set,
        And,
        Or,
        Not
    }
    
    public abstract class VariableModifier
    {
        public abstract void Modify();
    }
}