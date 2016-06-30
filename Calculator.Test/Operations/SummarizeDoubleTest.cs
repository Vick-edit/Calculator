﻿using Calculator.Operations;
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
    }
}