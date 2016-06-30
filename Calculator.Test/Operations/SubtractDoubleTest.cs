using System;
using Calculator.Operations;
using NUnit.Framework;

namespace Calculator.Test.Operations
{
    [TestFixture]
    public class SubtractDoubleTest
    {
        private readonly SubtractDouble _subtractor;

        public SubtractDoubleTest()
        {
            _subtractor = new SubtractDouble();
        }


        [TestCase(-94.86, -147.45)]
        [TestCase(-94.86, 147.45)]
        [TestCase(94.86, 147.45)]
        public void Calculate_SubtractFirstFromSecond_CorrectReturned(double firstNumber, double secondNumber)
        {
            //arrange
            var correctResult = firstNumber - secondNumber;

            //act
            var result = _subtractor.Calculate(firstNumber, secondNumber);

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

        [TestCase(1e308, -1e308)]
        [TestCase(-1e308, 1e308)]
        public void Calculate_SubtractBigAbsoluteValue_OverflowExceptionRaised(double firstNumber, double secondNumber)
        {
            Calculate_ActAssertForException<OverflowException>(firstNumber, secondNumber);
        }


        private void Calculate_ActAssertForException<T>(double firstNumber, double secondNumber) where T : Exception
        {
            //act
            TestDelegate result = () => _subtractor.Calculate(firstNumber, secondNumber);

            //assert
            Assert.Throws<T>(result);
        }
    }
}