namespace Calculator.Operations
{
    public class SummarizeDouble : IBinaryOperation<double>
    {
        public double Calculate(double first, double second)
        {
            double result = first + second;
            return result;
        }
    }
}