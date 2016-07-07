using System;
using System.Collections.Generic;
using Calculator.MathCore;
using Calculator.OperationContainers;
using Calculator.Operations;
using Calculator.Parsers;
using Moq;
using NUnit.Framework;

namespace Calculator.Test.Parsers
{
    [TestFixture]
    public class ParserBinaryOperationsTest
    {
        protected readonly ParserNumberDouble NumberParser;


        public ParserBinaryOperationsTest()
        {
            var numberTest = new ParserNumberDoubleTest();
            NumberParser = numberTest.Parser;
        }


        [TestCase("2+2*2", 6)]
        [TestCase("2*2-2*2", 0)]
        [TestCase("3+3:3", 4)]
        public void ParsString_ParsThreeBinaryOperation_CorrectResultNumber(string expresion, double controlResult)
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


        protected virtual IParser<double> BuildParser(IParserNumber<double> numberParser, IBinaryOperationMap<double> binaryMapper)
        {
            return new ParserBinaryOperations<double>(numberParser, binaryMapper);
        }

        protected List<IBinaryOperationContainer<double>> BuildBinaryOperationContainers(Dictionary<string, Func<double, double, double>> operationsDinctionary)
        {
            var opertionsContainers = new List<IBinaryOperationContainer<double>>();

            //по словарю символ - операция создаём упорядоченный список контейнеров функций
            foreach (var keyValuePair in operationsDinctionary)
            {
                var symbol = keyValuePair.Key;
                var func = keyValuePair.Value;

                var opertionMock = Mock.Of<IBinaryOperation<double>>();
                Mock.Get(opertionMock)
                    .Setup(x => x.Calculate(It.IsAny<double>(), It.IsAny<double>()))
                    .Returns((double a, double b) => func(a, b));

                var opertionContainerMock = Mock.Of<IBinaryOperationContainer<double>>();
                Mock.Get(opertionContainerMock)
                    .SetupGet(x => x.Symbol)
                    .Returns(symbol);
                Mock.Get(opertionContainerMock)
                    .SetupGet(x => x.Operation)
                    .Returns(opertionMock);

                opertionsContainers.Add(opertionContainerMock);
            }
            return opertionsContainers;
        }
    }
}