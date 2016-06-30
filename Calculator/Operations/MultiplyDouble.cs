namespace Calculator.Operations
{
    public class MultiplyDouble : IBinaryOperation<double>
    {
        public double Calculate(double first, double second)
        {
            return first*second;
        }
    }
}