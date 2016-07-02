using System.Collections.Generic;
using Calculator.OperationContainers;
using Calculator.Operations;

namespace Calculator.StringMathCore
{
    public interface IBinaryPartsOfMath<T> where T : struct
    {
        IBinaryOperationContainer<T>[] GetOperationContainersSortedByPriority();
    }
}