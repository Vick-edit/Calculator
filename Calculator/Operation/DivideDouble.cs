using System;

namespace Calculator.Operations
{
    public class DivideDouble : IBinaryOperation<double>
    {
        private const double NearlyZero = 1e-300;

        public double Calculate(double first, double second)
        {
            if (IsAnyInvalid(first, second))
                throw new ArgumentException("Некорректное значение аргумента операции");
            if(IsAnyTooBigOrSmall(first, second))
                throw new ArgumentOutOfRangeException("Аргумент операции вышел за пределы допустимых значений", (Exception)null);

            var result = first/second;

            if (IsWasDivideByZero(second, result))
                throw new DivideByZeroException("Деление на ноль");
            if (TooBigAbsoluteValue(result))
                throw new OverflowException("Результат вычисления имеет слишком большое значение по модулю");

            return result;
        }

        private static bool IsAnyTooBigOrSmall(double first, double second)
        {
            return double.IsInfinity(first) || double.IsInfinity(second);
        }

        private static bool IsAnyInvalid(double first, double second)
        {
            return double.IsNaN(first) || double.IsNaN(second);
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