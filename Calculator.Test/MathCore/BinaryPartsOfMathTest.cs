using System.Collections.Generic;
using System.Linq;
using Calculator.MathCore;
using Calculator.OperationContainers;
using Calculator.Operations;
using Moq;
using NUnit.Framework;

namespace Calculator.Test.MathCore
{
    [TestFixture]
    public class BinaryPartsOfMathTest
    {
        [Test]
        public void GetOperationContainersSortedByPriority_EveryContainerHasUniqueSymbol()
        {
            //arrange
            var factory = Mock.Of<IBaseBinaryOperationsFactory<double>>();
            Mock.Get(factory).Setup(x => x.GetMultiplier()).Returns((IBinaryOperation<double>) null);
            Mock.Get(factory).Setup(x => x.GetDivider()).Returns((IBinaryOperation<double>)null);
            Mock.Get(factory).Setup(x => x.GetSubtractor()).Returns((IBinaryOperation<double>)null);
            Mock.Get(factory).Setup(x => x.GetSummarizer()).Returns((IBinaryOperation<double>)null);

            var builder = Mock.Of<IBinaryOperationContainerBuilder<double>>();
            Mock.Get(builder).Setup(y => y.BuildContainer(It.IsAny<string>(), null))
                .Returns<string, object>((symbol, obj) => new BinaryOperationContainer<double>(symbol, null));

            var binaryPartsofMath = new BinaryPartsOfMath<double>(factory, builder);


            //act
            var operationContainers = binaryPartsofMath.OrderedOperationContainersByPriority().ToList();
            var duplicatesExist = false;
            foreach (var container in operationContainers)
            {
                var symbol = container.Symbol;

                int counter = 0;
                foreach (var otherContainer in operationContainers)
                {
                    if (otherContainer.Symbol == symbol || otherContainer.Symbol.Contains(symbol))
                        counter++;
                }

                duplicatesExist |= counter > 1;
            }


            //assert
            Assert.That(duplicatesExist, Is.False);
        }
    }
}