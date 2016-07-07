using System;
using System.Globalization;
using Sprache;

namespace Calculator.Parsers
{
    /// <summary> 
    /// Класс для парсинга чисел - инкапсулирует дерево 
    /// для парсинга чисел типа doble в формате записи  
    /// [-]{число}[.{число}] -4.96
    /// </summary>
    public class ParserNumberDouble : IParserNumber<double>
    {
        private Parser<string> FractionalNumberPart
        {
            get
            {
                return
                    from dot in Parse.Char('.')
                    from fractionNumbers in Parse.Number
                    from end in Parse.Not(Parse.Letter)
                    select dot + fractionNumbers;
            }
        }

        private Parser<string> PositiveNumber
        {
            get
            {
                return
                    from integer in Parse.Number
                    from fraction in FractionalNumberPart.XOr(Parse.Return(string.Empty))
                    select integer + fraction;
            }
        }

        private Parser<string> NegativeNumber
        {
            get
            {
                return
                    from minus in Parse.Char('-')
                    from number in PositiveNumber
                    select minus + number;
            }
        }

        private Parser<string> StringNumber
        {
            get { return NegativeNumber.XOr(PositiveNumber); }
        }


        public Parser<double> Number
        {
            get
            {
                return
                    from num in StringNumber
                    select double.Parse(num, CultureInfo.InvariantCulture);
            }
        }

        public double ParsString(string expresion)
        {
            var lambdaByParser = Number.End();
            var result = lambdaByParser.Parse(expresion);
            return result;
        }
    }
}