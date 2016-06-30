using System;

namespace Calculator.Operations
{
    public class MultiplyDouble : IBinaryOperation<double>
    {
        public double Calculate(double first, double second)
        {
            if (IsAnyInvalid(first, second))
                throw new ArgumentException("Некорректное значение аргумента операции");
            if (IsAnyTooBigOrSmall(first, second))
                throw new ArgumentOutOfRangeException("Аргумент операции вышел за пределы допустимых значений", (Exception)null);

            var result = first*second;

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

        private static bool TooBigAbsoluteValue(double result)
        {
            return double.IsInfinity(result);
        }
    }
}