using System;
using Calculator.Operations;
using NUnit.Framework;

namespace Calculator.Test.Operations
{
    [TestFixture]
    public class SubtractDoubleTest
    {
        [TestCase(-94.86, -147.45)]
        [TestCase(-94.86, 147.45)]
        [TestCase(94.86, 147.45)]
        public void Calculate_SubtractFirstFromSecond_CorrectReturned(double firstNumber, double secondNumber)
        {
            //arrange
            var subtractor = new SubtractDouble();
            var correctResult = firstNumber - secondNumber;

            //act
            var result = subtractor.Calculate(firstNumber, secondNumber);

            //assert
            Assert.That(result, Is.EqualTo(correctResult));
        }

        [TestCase(1e308, -1e308)]
        [TestCase(-1e308, 1e308)]
        public void Calculate_SubtractBigAbsoluteValue_OverflowExceptionRaised(double firstNumber, double secondNumber)
        {
            //arrange
            var subtractor = new SubtractDouble();

            //act
            TestDelegate result = () => subtractor.Calculate(firstNumber, secondNumber);

            //assert
            Assert.Throws<OverflowException>(result);
        }
    }
}