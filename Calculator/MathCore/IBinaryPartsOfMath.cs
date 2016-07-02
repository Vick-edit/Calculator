using Calculator.OperationContainers;
using Calculator.Operations;

namespace Calculator.MathCore
{
    public interface IBinaryPartsOfMath<T> where T : struct
    {
        IBinaryOperationContainer<T>[] OrderedOperationContainersByPriority();
    }
}