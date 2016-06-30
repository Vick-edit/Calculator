namespace Calculator.Operations
{
    //Сделал так, потому что вполне вероятно, что заказчик может захотеть считать в decimal или int
    public interface IBinaryOperation<T> where T : struct 
    {
        T Calculate(T first, T second);
    }
}