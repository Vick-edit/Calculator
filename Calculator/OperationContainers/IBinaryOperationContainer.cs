using Calculator.Operations;

namespace Calculator.Containers
{
    public interface IBinaryOperationContainer<T> where T: struct 
    {
        string[] Literals { get; }
        IBinaryOperation<T> Operation { get; } 
    }
}