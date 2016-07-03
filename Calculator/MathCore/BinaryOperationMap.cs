using System.Collections.Generic;
using System.Linq;
using Calculator.OperationContainers;
using Calculator.Operations;


namespace Calculator.MathCore
{
    /// <summary> Хаб - класс, хранит мапинг приоритет операции - символ - сама операция </summary>
    public class BinaryOperationMap<T> : IBinaryOperationMap<T> where T : struct 
    {
        private readonly IBaseBinaryOperationsFactory<T> _operationsfactory;
        private readonly IBinaryOperationContainerBuilder<T> _containerBuilder;

        private readonly Dictionary<OperationsPriority, string> _symbolsDictionary;
        private readonly Dictionary<OperationsPriority, IBinaryOperation<T>> _operationDictionary;

        private readonly Dictionary<OperationsPriority, IBinaryOperationContainer<T>> _operationContainers;


        public BinaryOperationMap(IBaseBinaryOperationsFactory<T> factory, IBinaryOperationContainerBuilder<T> containerBuilder)
        {
            _operationsfactory = factory;
            _containerBuilder = containerBuilder;

            _symbolsDictionary = SymbolsMap();
            _operationDictionary = OperationsMap();
            _operationContainers = MakeContainersDictionary();
        }


        /// <summary> Словарь приоритет операции - символ </summary>
        private Dictionary<OperationsPriority, string> SymbolsMap()
        {
            var symbolsDictionary =
                new Dictionary<OperationsPriority, string>
                {
                    {OperationsPriority.Multiplication, "*"},
                    {OperationsPriority.Division, ":"},
                    {OperationsPriority.Subtraction, "-"},
                    {OperationsPriority.Summation, "+"}
                };
            return symbolsDictionary;
        }

        /// <summary> Словарь приоритет - сама операция </summary>
        private Dictionary<OperationsPriority, IBinaryOperation<T>> OperationsMap()
        {
            var operationsDictionary =
                new Dictionary<OperationsPriority, IBinaryOperation<T>>
                {
                    {OperationsPriority.Multiplication, _operationsfactory.GetMultiplier()},
                    {OperationsPriority.Division, _operationsfactory.GetDivider()},
                    {OperationsPriority.Subtraction, _operationsfactory.GetSubtractor()},
                    {OperationsPriority.Summation, _operationsfactory.GetSummarizer()}
                };
            return operationsDictionary;
        }

        /// <summary> Объединение словарей в один приоритет-символ-операция </summary>
        private Dictionary<OperationsPriority, IBinaryOperationContainer<T>> MakeContainersDictionary()
        {
            var containersDictionary = new Dictionary<OperationsPriority, IBinaryOperationContainer<T>>();

            foreach (var dictionaryEntry in _operationDictionary)
            {
                var symbol = _symbolsDictionary[dictionaryEntry.Key];
                var operation = dictionaryEntry.Value;
                var operationContainer = _containerBuilder.BuildContainer(symbol, operation);

                containersDictionary.Add(dictionaryEntry.Key, operationContainer);
            }

            return containersDictionary;
        }

        public IBinaryOperationContainer<T>[] OrderedOperationContainersByPriority()
        {
            var orderedContainers = _operationContainers.OrderBy(x => (int)x.Key).Select(x => x.Value);
            return orderedContainers.ToArray();
        }
    }
}