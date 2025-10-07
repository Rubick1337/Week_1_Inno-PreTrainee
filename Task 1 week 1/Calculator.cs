using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_week_1
{
    public class Calculator
    {
        public enum Operation
        {
            Add,
            Subtract,
            Multiply,
            Divide
        }
        private static readonly Dictionary<char, Operation> operationMap = new Dictionary<char, Operation>()
        {
            { '+',Operation.Add },
            {'-',Operation.Subtract},
            {'*',Operation.Multiply},
            {'/', Operation.Divide },
        };
            public static Operation GetOperationFromSymbol(char symbol)
            {
                if (operationMap.TryGetValue(symbol, out Operation operation))
                {
                    return operation;
                }
                throw new ArgumentException($"Неподдерживаемая операция: '{symbol}'");
            }
        public static char[] GetAvailableOperationSymbols()
        {
            return operationMap.Keys.ToArray();
        }

        private static double Add(double a , double b)
        {
            return a + b;
        }
        private static double Subtract(double a , double b) 
        {
            return a - b; 
        }
        private static double Multiply(double a, double b)
        {
            return a * b;
        }
        private static double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Ошибка: Деление на ноль");
            }
            return a / b;
        }
        public static double Calculate(double a, double b, char inputOperation)
        {
            Operation operation = GetOperationFromSymbol(inputOperation);
            switch (operation)
            {
                case Operation.Add:
                    return Add(a, b);

                case Operation.Subtract:
                    return Subtract(a, b);

                case Operation.Multiply:
                    return Multiply(a, b);

                case Operation.Divide:
                    return Divide(a, b);

                default:
                    throw new InvalidOperationException($"Ошибка: Операция '{operation}' не поддерживается.");
            }
        }
    }
}
