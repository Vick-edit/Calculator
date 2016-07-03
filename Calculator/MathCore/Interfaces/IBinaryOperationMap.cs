using Calculator.OperationContainers;
using Calculator.Operations;

namespace Calculator.MathCore
{
    public interface IBinaryOperationMap<T> where T : struct
    {
        IBinaryOperationContainer<T>[] OrderedOperationContainersByPriority();
    }
}