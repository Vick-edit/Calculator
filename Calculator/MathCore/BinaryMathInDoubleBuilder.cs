using System.Dynamic;
using Calculator.OperationContainers;
using Calculator.Operations;

namespace Calculator.MathCore
{
    public class BinaryMathInDoubleBuilder : IBinaryMathBuilder<double>
    {
        public IBinaryOperationMap<double> GetBinaryMathCore()
        {
            var operationsFactory = new BaseBinaryOperationsFactoryDouble();
            var operationsContainerBuilder = new BinaryOperationContainerBuilder<double>();

            var mathCore = new BinaryOperationMap<double>(operationsFactory, operationsContainerBuilder);
            return mathCore;
        }
    }
}