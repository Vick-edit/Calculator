namespace Calculator.Operations
{
    public interface IBaseBinaryOperationsFactory<T> where T : struct
    {
        IBinaryOperation<T> GetMultiplier();
        IBinaryOperation<T> GetDivider();
        IBinaryOperation<T> GetSubtractor();
        IBinaryOperation<T> GetSummarizer();
    }
}