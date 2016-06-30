namespace Calculator.Operations
{
    public class SubtractDouble : IBinaryOperation<double>
    {
        public double Calculate(double first, double second)
        {
            return first - second;
        }
    }
}