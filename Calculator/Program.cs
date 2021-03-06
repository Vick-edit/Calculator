﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator.Parsers;

namespace Calculator
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Консольный калькулятор");
            Console.WriteLine();
            Console.WriteLine("Список поддерживаемых функций:\n" +
                              "*  -  умножение\n" +
                              ":  -  деление\n" +
                              "+  -  сложение\n" +
                              "-  -  вычитание\n");
            Console.WriteLine();
            Console.WriteLine("Также поддерживается группировка при помощи круглых скобок");
            Console.WriteLine("Формат числа - десятичная дробь, разделитель - точка");
            Console.WriteLine();

            var parser = new ParsersBuilder().ParserForDoubleBinariesAndBrakets();

            while (true)
            {
                try
                {
                    ParseInput(parser);
                }
                catch (Exception e)
                {
                    HandleException(e);
                }

            }
        }

        private static void ParseInput(IParser<double> parser)
        {
            Console.Write("Введите выражение: ");
            var input = Console.ReadLine();
            var result = parser.ParsString(input);
            var message = string.Format(CultureInfo.InvariantCulture, "Результат вычисления: {0}", result);

            Console.WriteLine(message);
            Console.ReadKey(true);
            Console.WriteLine();
        }

        private static void HandleException(Exception e)
        {
            while (e.InnerException != null)
            {
                e = e.InnerException;
            }

            Console.WriteLine("В ходе работы парсера возникла ошибка: ");
            Console.WriteLine(e.Message + "\n\n");
        }
    }
}
