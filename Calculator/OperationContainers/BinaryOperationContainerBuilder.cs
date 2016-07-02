using Calculator.Operations;

namespace Calculator.OperationContainers
{
    public class BinaryOperationContainerBuilder<T> : IBinaryOperationContainerBuilder<T> where T : struct 
    {
        public IBinaryOperationContainer<T> BuildContainer(string[] literals, IBinaryOperation<T> operation)
        {
            return new BinaryOperationContainer<T>(literals, operation);
        }
    }
}