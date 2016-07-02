using System.Collections.Generic;
using Calculator.OperationContainers;
using Calculator.Operations;

namespace Calculator.StringMathCore
{
    public class BinaryPartsOfMath<T> : IBinaryPartsOfMath<T> where T : struct 
    {
        public IBinaryOperationContainer<T>[] GetOperationContainersSortedByPriority()
        {
            throw new System.NotImplementedException();
        }
    }
}