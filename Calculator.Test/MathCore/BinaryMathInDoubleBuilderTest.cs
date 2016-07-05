using Calculator.MathCore;
using NUnit.Framework;

namespace Calculator.Test.MathCore
{
    [TestFixture]
    public class BinaryMathInDoubleBuilderTest
    {
        [Test]
        public void GetBinaryMathCore_GetObject_ReturnNotNull()
        {
            //arrange
            var binaryMathInDoubleBuilder = new BinaryMathInDoubleBuilder();

            //act
            var result = binaryMathInDoubleBuilder.GetBinaryMathCore();

            //assert
            Assert.That(result, Is.Not.Null);
        }
    }
}