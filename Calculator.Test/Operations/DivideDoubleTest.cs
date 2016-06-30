using System;
using Calculator.Operations;
using NUnit.Framework;

namespace Calculator.Test.Operations
{
    [TestFixture]
    public class DivideDoubleTest
    {
        private readonly DivideDouble _divider;

        public DivideDoubleTest()
        {
            _divider = new DivideDouble();
        }


        [TestCase(-94.86, -147.45)]
        [TestCase(-94.86, 147.45)]
        [TestCase(94.86, 147.45)]
        public void Calculate_DivideFirsBySecont_CorrectReturned(double firstNumber, double secondNumber)
        {
            //arrange
            var correctResult = firstNumber / secondNumber;

            //act
            var result = _divider.Calculate(firstNumber, secondNumber);

            //assert
            Assert.That(result, Is.EqualTo(correctResult));
        }


        [TestCase(1d, double.PositiveInfinity)]
        [TestCase(double.NegativeInfinity, 1d)]
        public void Calculate_TryPassInfinity_OutOfRangeRaised(double firstNumber, double secondNumber)
        {
            Calculate_ActAssertForException<ArgumentOutOfRangeException>(firstNumber, secondNumber);
        }


        [TestCase(1d, double.NaN)]
        [TestCase(double.NaN, 1d)]
        public void Calculate_TryNan_ArgumentExceptionRaised(double firstNumber, double secondNumber)
        {
            Calculate_ActAssertForException<ArgumentException>(firstNumber, secondNumber);
        }


        [TestCase(-1e300, 1e-200)]
        [TestCase(-1e300, -1e-200)]
        public void Calculate_DivideBySmallAbsoluteValue_OverflowExceptionRaised(double firstNumber, double secondNumber)
        {
            Calculate_ActAssertForException<OverflowException>(firstNumber, secondNumber);
        }


        [TestCase(0, 0)]
        [TestCase(0.86, 0.0)]
        [TestCase(149.845654, -0)]
        public void Calculate_DivideByZero_DivideByZeroExceptionRaised(double firstNumber, double secondNumber)
        {
            Calculate_ActAssertForException<DivideByZeroException>(firstNumber, secondNumber);
        }


        private void Calculate_ActAssertForException<T>(double firstNumber, double secondNumber) where T : Exception
        {
            //act
            TestDelegate result = () => _divider.Calculate(firstNumber, secondNumber);

            //assert
            Assert.Throws<T>(result);
        }
    }
}