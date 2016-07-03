using System.Dynamic;
using Calculator.OperationContainers;
using Calculator.Operations;

namespace Calculator.MathCore
{
    public class BinaryMathInDoubleBuilder : IBinaryMathBuilder<double>
    {
        public IBinaryPartsOfMath<double> GetBinaryMathCore()
        {
            var operationsFactory = new BaseBinaryOperationsFactoryDouble();
            var operationsContainerBuilder = new BinaryOperationContainerBuilder<double>();

            var mathCore = new BinaryPartsOfMath<double>(operationsFactory, operationsContainerBuilder);
            return mathCore;
        }
    }
}