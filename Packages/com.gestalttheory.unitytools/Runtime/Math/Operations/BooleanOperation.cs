namespace UnityTools.Runtime.Math.Operations
{
    public static class BooleanOperation
    {
        public static bool Modify(this bool source, BooleanOperator op, bool value)
        {
            return op switch
            {
                BooleanOperator.Equal => value,
                BooleanOperator.And => source && value,
                BooleanOperator.Or => source || value,
                _ => throw new System.ArgumentOutOfRangeException()
            };
        }
    }
}