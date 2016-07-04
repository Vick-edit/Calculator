using Sprache;

namespace Calculator.Parsers
{
    public interface IParserNumber<T> where T : struct
    {
        Parser<T> Number { get; }
    }
}