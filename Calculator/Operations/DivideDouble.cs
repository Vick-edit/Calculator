using System;

namespace Calculator.Operations
{
    public class DivideDouble : IBinaryOperation<double>
    {
        private const double NearlyZero = 1e-300;

        public double Calculate(double first, double second)
        {
            var result = first/second;

            if (IsWasDivideByZero(second, result))
                throw new DivideByZeroException("Деление на ноль");

            if (TooBigAbsoluteValue(result))
                throw new OverflowException("Результат вычисления имеет слишком большое значение по модулю");


            return result;
        }

        private bool IsWasDivideByZero(double second, double result)
        {
            var badResult = double.IsInfinity(result) || double.IsNaN(result);
            var nearlyZeroDivisor = Math.Abs(second) < NearlyZero;

            return badResult && nearlyZeroDivisor;
        }

        private static bool TooBigAbsoluteValue(double result)
        {
            return double.IsInfinity(result);
        }
    }
}