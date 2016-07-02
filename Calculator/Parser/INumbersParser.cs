using System.Linq.Expressions;
using Sprache;

namespace Calculator.Parser
{
    public interface INumbersParser<T> where T : struct 
    {
        Parser<T> Number { get; }
    }
}