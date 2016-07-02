using Calculator.Operations;

namespace Calculator.OperationContainers
{
    public class BinaryOperationContainer<T> : IBinaryOperationContainer<T> where T : struct 
    {
        public string Symbol { get; private set; }
        public IBinaryOperation<T> Operation { get; private set; }

        public BinaryOperationContainer(string symbol, IBinaryOperation<T> operation)
        {
            Symbol = symbol;
            Operation = operation;
        }
    }
}