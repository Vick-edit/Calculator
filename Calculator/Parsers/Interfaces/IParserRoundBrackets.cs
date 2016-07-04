using System.Linq.Expressions;
using Sprache;

namespace Calculator.Parsers
{
    public interface IParserRoundBrackets<T> : IParserBinaryOperations<T> where T : struct 
    {
        Parser<Expression> ExpressionInBrackets { get; }
    }
}