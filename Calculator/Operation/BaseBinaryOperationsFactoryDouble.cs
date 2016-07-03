namespace Calculator.Operations
{
    public class BaseBinaryOperationsFactoryDouble : IBaseBinaryOperationsFactory<double>
    {
        public IBinaryOperation<double> GetMultiplier()
        {
            return new MultiplyDouble();
        }

        public IBinaryOperation<double> GetDivider()
        {
            return new DivideDouble();
        }

        public IBinaryOperation<double> GetSubtractor()
        {
            return new SubtractDouble();
        }

        public IBinaryOperation<double> GetSummarizer()
        {
            return new SummarizeDouble();
        }
    }
}