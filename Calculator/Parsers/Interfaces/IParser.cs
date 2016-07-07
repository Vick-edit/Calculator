namespace Calculator.Parsers
{
    public interface IParser<T> where T : struct 
    {
        T ParsString(string expresion);
    }
}