namespace UnityTools.Runtime.Math.Operations
{
    public static class NumericalOperation
    {
        public static int Modify(this int input, NumericalOperator op, int value)
        {
            return (int) ((decimal) input).Modify(op, value);
        }
        
        public static float Modify(this float input, NumericalOperator op, float value)
        {
            return (float) ((decimal) input).Modify(op, (decimal) value);
        }
        
        public static long Modify(this long input, NumericalOperator op, long value)
        {
            return (long) ((decimal) input).Modify(op, value);
        }
        
        public static double Modify(this double input, NumericalOperator op, double value)
        {
            return (double) ((decimal) input).Modify(op, (decimal) value);
        }
        
        private static decimal Modify(this decimal input, NumericalOperator op, decimal value)
        {
            return op switch
            {
                NumericalOperator.AddValue => input + value,
                NumericalOperator.AddPercentage => input + input * value / 100,
                NumericalOperator.SetEqualTo => value,
                NumericalOperator.MultiplyBy => input * value,
                NumericalOperator.DivideBy => value == 0 ? input : input / value,
                _ => throw new System.ArgumentOutOfRangeException()
            };
        }
    }
}