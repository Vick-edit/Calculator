using System.Linq.Expressions;
using Calculator.MathCore;
using Sprache;

namespace Calculator.Parsers
{
    public class ParserRoundBrackets<T> : ParserBinaryOperations<T>, IParserRoundBrackets<T> where T : struct 
    {        
        public Parser<Expression> ExpressionInBrackets { get; private set; }
        
        public ParserRoundBrackets(IParserNumber<T> numberParser, IBinaryOperationMap<T> binaryMapper) 
            : base(numberParser, binaryMapper)
        {
        }
    }
}