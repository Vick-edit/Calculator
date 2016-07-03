using System.Linq.Expressions;
using Sprache;

namespace Calculator.Parsers
{
    public interface IParserBinaryOperations<T> where T : struct
    {
        Parser<Expression> Operand { get; }

        Parser<Expression> OrderedExpressions { get; }

        T ParsString(string expresion);
    }
}