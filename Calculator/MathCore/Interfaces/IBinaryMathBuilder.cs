namespace Calculator.MathCore
{
    public interface IBinaryMathBuilder<T> where T : struct
    {
        IBinaryOperationMap<T> GetBinaryMathCore();
    }
}