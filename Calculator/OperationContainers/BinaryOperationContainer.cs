using Calculator.Operations;

namespace Calculator.Containers
{
    public class BinaryOperationContainer<T> : IBinaryOperationContainer<T> where T : struct 
    {
        public string[] Literals { get; private set; }
        public IBinaryOperation<T> Operation { get; private set; }

        public BinaryOperationContainer(string[] literals, IBinaryOperation<T> operation)
        {
            Literals = literals;
            Operation = operation;
        }
    }
}