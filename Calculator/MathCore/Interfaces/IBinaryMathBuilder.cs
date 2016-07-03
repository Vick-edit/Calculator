namespace Calculator.MathCore
{
    public interface IBinaryMathBuilder<T> where T : struct
    {
        IBinaryPartsOfMath<T> GetBinaryMathCore();
    }
}