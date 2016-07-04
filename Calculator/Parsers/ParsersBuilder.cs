using Calculator.MathCore;

namespace Calculator.Parsers
{
    public class ParsersBuilder
    {
        public IParserRoundBrackets<double> ParserForDoubleBinariesAndBrakets()
        {
            var binarysMap = new BinaryMathInDoubleBuilder().GetBinaryMathCore();
            var numberParser = new ParserNumberDouble();

            var parser = new ParserRoundBrackets<double>(numberParser, binarysMap);
            return parser;
        }
    }
}