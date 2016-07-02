using Calculator.Operations;

namespace Calculator.OperationContainers
{
    public interface IBinaryOperationContainerBuilder<T> where T : struct
    {
        IBinaryOperationContainer<T> BuildContainer(string[]symbols, IBinaryOperation<T> operation);
    }
}