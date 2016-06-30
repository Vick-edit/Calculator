using System;

namespace Calculator.Operations
{
    public class DivideDouble : IBinaryOperation<double>
    {
        public double Calculate(double first, double second)
        {
            var result = first/second;

            if (IsWasDivideByZero(result))
                throw new DivideByZeroException();

            return result;
        }

        private bool IsWasDivideByZero(double result)
        {
            return double.IsInfinity(result) || double.IsNaN(result);
        }
    }
}