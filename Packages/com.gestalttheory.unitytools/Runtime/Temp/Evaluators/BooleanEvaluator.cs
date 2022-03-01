namespace UnityTools.Runtime
{
    public enum BooleanEvaluation
    {
        EqualTo,
        NotEqualTo
    }
    
    public static class BooleanEvaluator
    {
        public static bool Evaluate(this bool valueA, BooleanEvaluation evaluation, bool valueB)
        {
            return evaluation switch
            {
                BooleanEvaluation.EqualTo => valueA.CompareTo(valueB) == 0,
                BooleanEvaluation.NotEqualTo => valueA.CompareTo(valueB) != 0,
                _ => false
            };
        }
    }
}
