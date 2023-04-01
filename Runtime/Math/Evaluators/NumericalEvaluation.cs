namespace UnityTools.Runtime.Math
{
    public enum NumericalEvaluation
    {
        EqualOrLesserThan,
        EqualOrGreaterThan,
        NotEqualTo,
        EqualTo
    }
    
    public static partial class MathExtensions
    {
        public static bool Evaluate(this int valueA, NumericalEvaluation evaluation, int valueB)
        {
            return ((long) valueA).Evaluate(evaluation, valueB);
        }
        
        public static bool Evaluate(this float valueA, NumericalEvaluation evaluation, float valueB)
        {
            return ((decimal) valueA).Evaluate(evaluation, (decimal) valueB);
        }
        
        public static bool Evaluate(this long valueA, NumericalEvaluation evaluation, long valueB)
        {
            return ((decimal) valueA).Evaluate(evaluation, valueB);
        }
        
        public static bool Evaluate(this double valueA, NumericalEvaluation evaluation, double valueB)
        {
            return ((decimal) valueA).Evaluate(evaluation, (decimal) valueB);
        }
        
        private static bool Evaluate(this decimal valueA, NumericalEvaluation evaluation, decimal valueB)
        {
            return evaluation switch
            {
                NumericalEvaluation.EqualOrLesserThan => valueA.CompareTo(valueB) <= 0,
                NumericalEvaluation.EqualOrGreaterThan => valueA.CompareTo(valueB) >= 0,
                NumericalEvaluation.NotEqualTo => valueA.CompareTo(valueB) != 0,
                NumericalEvaluation.EqualTo => valueA.CompareTo(valueB) == 0,
                _ => false
            };
        }
    }
}