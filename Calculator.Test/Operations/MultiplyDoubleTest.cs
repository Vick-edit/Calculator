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
    }
}