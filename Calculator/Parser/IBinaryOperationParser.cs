using System;
using System.Linq.Expressions;
using Sprache;

namespace Calculator.Parser
{
    public interface IBinaryOperationParser<T> where T : struct
    {
        Parser<Expression<Func<T, T, T>>> Divide { get; }

        Parser<Expression<Func<T, T, T>>> Multiply { get; }

        Parser<Expression<Func<T, T, T>>> Subtract { get; }

        Parser<Expression<Func<T, T, T>>> Summarize { get; }
    }
}