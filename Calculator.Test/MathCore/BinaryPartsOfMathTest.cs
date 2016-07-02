using System.Collections.Generic;
using System.Linq;
using Calculator.MathCore;
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
            var binaryPartsofMath = new BinaryPartsOfMath<double>();

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