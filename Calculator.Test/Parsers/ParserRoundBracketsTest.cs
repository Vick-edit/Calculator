using System;
using System.Collections.Generic;
using Calculator.MathCore;
using Calculator.Parsers;
using Moq;
using NUnit.Framework;

namespace Calculator.Test.Parsers
{
    [TestFixture]
    public class ParserRoundBracketsTest : ParserBinaryOperationsTest
    {

        [TestCase("(2+2)*2", 8)]
        [TestCase("(2*2-2)*2", 4)]
        [TestCase("(3+3):3", 2)]
        public void ParsString_ParsExpressionsWithBrackets_CorrectResultNumber(string expresion, double controlResult)
        {
            //arrange
            //Словарь обрабатываемых операций
            var operationsDinctionary = new Dictionary<string, Func<double, double, double>>()
            {
                {"*", (a, b) => a*b},
                {":", (a, b) => a/b},
                {"-", (a, b) => a-b},
                {"+", (a, b) => a+b}
            };
            var opertionsContainers = BuildBinaryOperationContainers(operationsDinctionary);

            //Мапер бинарных функций
            var binaryMapper = Mock.Of<IBinaryOperationMap<double>>();
            Mock.Get(binaryMapper)
                .Setup(x => x.OrderedOperationContainersByPriority())
                .Returns(opertionsContainers.ToArray);

            var parser = BuildParser(NumberParser, binaryMapper);


            //act
            var result = parser.ParsString(expresion);

            //assert
            Assert.That(result.Equals(controlResult));
        }

        protected override IParser<double> BuildParser(IParserNumber<double> numberParser, IBinaryOperationMap<double> binaryMapper)
        {
            return new ParserRoundBrackets<double>(numberParser, binaryMapper);
        }
    }
}