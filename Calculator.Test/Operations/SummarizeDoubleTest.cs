using System;
using Calculator.Operations;
using NUnit.Framework;

namespace Calculator.Test.Operations
{
    [TestFixture]
    public class SummarizeDoubleTest
    {
        [TestCase(-94.86, -147.45)]
        [TestCase(-94.86, 147.45)]
        [TestCase(94.86, 147.45)]
        public void Calculate_SumTwoNumber_CorrectReturned(double firstNumber, double secondNumber)
        {
            //arrange
            var summarizer = new SummarizeDouble();
            var correctResult = firstNumber + secondNumber;

            //act
            var result = summarizer.Calculate(firstNumber, secondNumber);

            //assert
            Assert.That(result, Is.EqualTo(correctResult));
        }


        [TestCase(1d, double.PositiveInfinity)]
        [TestCase(double.NegativeInfinity, 1d)]
        public void Calculate_TryPassInfinity_OutOfRangeRaised(double firstNumber, double secondNumber)
        {
            //arrange 
            var summarizer = new SummarizeDouble();

            //act
            TestDelegate result = () => summarizer.Calculate(firstNumber, secondNumber);

            //assert
            Assert.Throws<ArgumentOutOfRangeException>(result);
        }


        [TestCase(1d, double.NaN)]
        [TestCase(double.NaN, 1d)]
        public void Calculate_TryNan_ArgumentExceptionRaised(double firstNumber, double secondNumber)
        {
            //arrange 
            var summarizer = new SummarizeDouble();

            //act
            TestDelegate result = () => summarizer.Calculate(firstNumber, secondNumber);

            //assert
            Assert.Throws<ArgumentException>(result);
        }

        [TestCase(-1e308, -1e308)]
        [TestCase(1e308, 1e308)]
        public void Calculate_SumTwoBigAbsoluteValue_OverflowExceptionRaised(double firstNumber, double secondNumber)
        {
            //arrange
            var summarizer = new SummarizeDouble();

            //act
            TestDelegate result = () => summarizer.Calculate(firstNumber, secondNumber);

            //assert
            Assert.Throws<OverflowException>(result);
        }
    }
}