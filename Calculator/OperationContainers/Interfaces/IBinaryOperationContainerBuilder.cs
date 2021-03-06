﻿using Calculator.Operations;

namespace Calculator.OperationContainers
{
    public interface IBinaryOperationContainerBuilder<T> where T : struct
    {
        IBinaryOperationContainer<T> BuildContainer(string symbol, IBinaryOperation<T> operation);
    }
}