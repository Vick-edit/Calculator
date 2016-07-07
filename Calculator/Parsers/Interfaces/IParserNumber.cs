using Sprache;

namespace Calculator.Parsers
{
    public interface IParserNumber<T> : IParser<T> where T : struct
    {
        Parser<T> Number { get; }
    }
}