using System;
using Calculator.Operations;
using NUnit.Framework;

namespace Calculator.Test.Operations
{
    [TestFixture]
    public class MultiplyDoubleTest
    {
        [TestCase(-94.86, -147.45)]
        [TestCase(-94.86, 147.45)]
        [TestCase(94.86, 147.45)]
        public void Calculate_MultiplyTwoNumber_CorrectReturned(double firstNumber, double secondNumber)
        {
            //arrange
            var multiplier = new MultiplyDouble();
            var correctResult = firstNumber * secondNumber;

            //act
            var result = multiplier.Calculate(firstNumber, secondNumber);

            //assert
            Assert.That(result, Is.EqualTo(correctResult));
        }


        [TestCase(-1e200, 1e200)]
        [TestCase(1e200, 1e200)]
        public void Calculate_MultiplyTwoBigAbsoluteValue_OverflowExceptionRaised(double firstNumber, double secondNumber)
        {
            //arrange
            var multiplier = new MultiplyDouble();

            //act
            TestDelegate result = () => multiplier.Calculate(firstNumber, secondNumber);

            //assert
            Assert.Throws<OverflowException>(result);
        }
    }
}