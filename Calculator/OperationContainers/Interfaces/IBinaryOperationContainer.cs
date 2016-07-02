using Calculator.Operations;

namespace Calculator.OperationContainers
{
    public interface IBinaryOperationContainer<T> where T: struct 
    {
        string[] Symbols { get; }
        IBinaryOperation<T> Operation { get; } 
    }
}