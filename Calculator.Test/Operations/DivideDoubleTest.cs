using System;
using Calculator.Operations;
using NUnit.Framework;

namespace Calculator.Test.Operations
{
    [TestFixture]
    public class DivideDoubleTest
    {
        [TestCase(-94.86, -147.45)]
        [TestCase(-94.86, 147.45)]
        [TestCase(94.86, 147.45)]
        public void Calculate_DivideFirsBySecont_CorrectReturned(double firstNumber, double secondNumber)
        {
            //arrange
            var divider = new DivideDouble();
            var correctResult = firstNumber / secondNumber;

            //act
            var result = divider.Calculate(firstNumber, secondNumber);

            //assert
            Assert.That(result, Is.EqualTo(correctResult));
        }


        [TestCase(-1e300d, 1e-200)]
        [TestCase(-1e300d, -1e-200)]
        public void Calculate_DivideBySmallAbsoluteValue_OverflowExceptionRaised(double firstNumber, double secondNumber)
        {
            //arrange
            var divider = new DivideDouble();

            //act
            TestDelegate result = () => divider.Calculate(firstNumber, secondNumber);

            //assert
            Assert.Throws<OverflowException>(result);
        }


        [TestCase(149.845654, -0)]
        [TestCase(0.86, 0.0)]
        [TestCase(0, 0)]
        public void Calculate_DivideByZero_DivideByZeroExceptionRaised(double firstNumber, double secondNumber)
        {
            //arrange
            var divider = new DivideDouble();

            //act
            TestDelegate result = () => divider.Calculate(firstNumber, secondNumber);

            //assert
            Assert.Throws<DivideByZeroException>(result);
        }
    }
}