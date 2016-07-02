using Calculator.OperationContainers;
using Calculator.Operations;

namespace Calculator.MathCore
{
    public class BinaryPartsOfMath<T> : IBinaryPartsOfMath<T> where T : struct 
    {
        public IBinaryOperationContainer<T>[] OrderedOperationContainersByPriority()
        {
            throw new System.NotImplementedException();
        }
    }
}