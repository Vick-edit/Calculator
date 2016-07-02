using Calculator.Operations;

namespace Calculator.OperationContainers
{
    public class BinaryOperationContainer<T> : IBinaryOperationContainer<T> where T : struct 
    {
        public string[] Symbols { get; private set; }
        public IBinaryOperation<T> Operation { get; private set; }

        public BinaryOperationContainer(string[] symbols, IBinaryOperation<T> operation)
        {
            Symbols = symbols;
            Operation = operation;
        }
    }
}