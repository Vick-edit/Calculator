using System.Linq.Expressions;
using Calculator.MathCore;
using Sprache;

namespace Calculator.Parsers
{
    public class ParserRoundBrackets<T> : ParserBinaryOperations<T>, IParserRoundBrackets<T> where T : struct 
    {
        public Parser<Expression> ExpressionInBrackets
        {
            get
            {
                return
                    from leftBracket in Parse.Char('(')
                    from expr in OrderedExpressions
                    from rightBracket in Parse.Char(')')
                    select expr;
            }
        }

        public override Parser<Expression> Operand
        {
            get { return ExpressionInBrackets.XOr(base.Operand); }
        }

        public ParserRoundBrackets(IParserNumber<T> numberParser, IBinaryOperationMap<T> binaryMapper) 
            : base(numberParser, binaryMapper)
        {
        }
    }
}