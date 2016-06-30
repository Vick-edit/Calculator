using System;

namespace Calculator.Operations
{
    public class SubtractDouble : IBinaryOperation<double>
    {
        public double Calculate(double first, double second)
        {
            var result = first - second;

            if (TooBigAbsoluteValue(result))
                throw new OverflowException("Результат вычисления имеет слишком большое значение по модулю");

            return result;
        }

        private static bool TooBigAbsoluteValue(double result)
        {
            return double.IsInfinity(result);
        }
    }
}