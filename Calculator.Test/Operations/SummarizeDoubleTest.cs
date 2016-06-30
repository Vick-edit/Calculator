using Calculator.Operations;
using NUnit.Framework;

namespace Calculator.Test.Operations
{
    [TestFixture]
    public class SummarizeDoubleTest
    {
        [TestCase(94.86, 147.45, 242.31)]
        public void Calculate_SumTwoPosistiv_CorrectPositivReturned(double firstNumber, double secondNumber, double correctSum)
        {
            //arrange
            var summarizer = new SummarizeDouble();

            //act
            var result = summarizer.Calculate(firstNumber, secondNumber);

            //assert
            Assert.That(result, Is.Positive);
            Assert.That(result, Is.EqualTo(correctSum));
        }
    }
}