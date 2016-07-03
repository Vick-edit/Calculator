using System.Linq.Expressions;
using Calculator.MathCore;
using Sprache;

namespace Calculator.Parsers
{
    public class ParserBinaryOperations<T> : IParserBinaryOperations<T> where T : struct
    {
        public Parser<Expression> Operand { get; private set; }

        public Parser<Expression> OrderedExpressions { get; private set; }


        public ParserBinaryOperations(ParserNumberDouble realNumberParser, IBinaryOperationMap<double> binaryMapper)
        {
            throw new System.NotImplementedException();
        }


        public T ParsString(string expresion)
        {
            throw new System.NotImplementedException();
        }
    }
}