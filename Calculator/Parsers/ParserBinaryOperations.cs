using System;
using System.Linq.Expressions;
using Calculator.MathCore;
using Sprache;

namespace Calculator.Parsers
{
    public class ParserBinaryOperations<T> : IParserBinaryOperations<T> where T : struct
    {
        private readonly IParserNumber<T> _numberParser;

        private readonly IBinaryOperationMap<T> _binaryOperationsMapper;

        private readonly Parser<Expression> _operand;
        public Parser<Expression> Operand { get { return _operand; } }

        private readonly Parser<Expression> _orderedExpressions;
        public Parser<Expression> OrderedExpressions { get{ return _orderedExpressions;} }

        private Parser<LambdaExpression> Lambda
        {
            get { return OrderedExpressions.End().Select(body => Expression.Lambda<Func<T>>(body)); }
        }


        public ParserBinaryOperations(IParserNumber<T> numberParser, IBinaryOperationMap<T> binaryMapper)
        {
            _numberParser = numberParser;
            _binaryOperationsMapper = binaryMapper;

            _operand = SetOperand();
            _orderedExpressions = SetOrderedExpressions();
        }

        public T ParsString(string expresion)
        {
            //Сначала даём построить дерево выражений по заданной строке
            var lambdaResult = Lambda.Parse(expresion) as Expression<Func<T>>;
            var funcResult = lambdaResult.Compile();
            return funcResult();
        }

        private Parser<Expression> SetOperand()
        {
            return
                from number in _numberParser.Number
                select Expression.Constant(number);
        }

        private Parser<Expression> SetOrderedExpressions()
        {
            var expression = Operand;

            var opertionContainers = _binaryOperationsMapper.OrderedOperationContainersByPriority();

            foreach (var containerElement in opertionContainers)
            {
                //Получаем смвол - операцию, к которой этот символ привязан
                var container = containerElement;
                string symbol = container.Symbol;
                Expression<Func<T, T, T>> opertion = (a, b) => container.Operation.Calculate(a, b);

                //создаём новое правило для дерева выражений
                var newExpression = RegisterNewBinaryExpression(symbol, opertion);

                //Создаём новую ветвь, таким образом, для данной операции аргументами могут стать операции более высокого уровня
                expression = Parse.XChainOperator(newExpression, expression, ApplyBinary);
            }

            return expression;
        }

        protected internal Parser<Expression<Func<T, T, T>>> RegisterNewBinaryExpression(string symbol, Expression<Func<T, T, T>> func)
        {
            return
                from charr in Parse.String(symbol)
                select func;
        }

        private Expression ApplyBinary(Expression<Func<T, T, T>> expression, Expression arg1, Expression arg2)
        {
            return Expression.Invoke(expression, arg1, arg2);
        }
    }
}