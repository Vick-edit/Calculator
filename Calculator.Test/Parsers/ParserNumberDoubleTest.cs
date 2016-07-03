using System.Globalization;
using Calculator.Parsers;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Sprache;

namespace Calculator.Test.Parsers
{
    [TestFixture]
    public class ParserNumberDoubleTest
    {
        public ParserNumberDouble Parser { get; private set; }

        public ParserNumberDoubleTest()
        {
            Parser = new ParserNumberDouble();
        }

        [TestCase("4.256")]
        [TestCase("0.793")]
        [TestCase("-83.9")]
        public void Number_ParseString_CorrectDouble(string expression)
        {
            //arrange
            var controlValue = double.Parse(expression, CultureInfo.InvariantCulture);

            //act
            var result = Parser.Number.Parse(expression);

            //assert
            Assert.That(result, Is.EqualTo(controlValue));
        }

        [TestCase(" 83.9")]
        [TestCase("83.9 ")]
        [TestCase("4.256d")]
        [TestCase("0.79.3")]
        [TestCase("--83.9")]
        public void Number_ParseIncorrectString_ExceptionRaised(string expression)
        {
            //act
            TestDelegate result = () => Parser.Number.Parse(expression);

            //assert
            Assert.Throws<ParseException>(result);
        }
    }
}