using Sprache;

namespace Calculator.Parsers
{
    public class ParserNumberDouble : IParserNumber<double>
    {
        public Parser<double> Number { get; private set; }
    }
}