namespace UnityTools.Runtime.Math
{
    public enum BooleanEvaluation
    {
        EqualTo,
        NotEqualTo
    }

    public static partial class MathExtensions
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