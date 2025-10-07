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
            private static Operation GetOperationFromSymbol(char symbol)
            {
                if (operationMap.TryGetValue(symbol, out Operation operation))
                {
                    return operation;
                }
                throw new ArgumentException($"Неподдерживаемая операция: '{symbol}'");
            }
        private static string GetOperationDescription(Operation operation)
        {
            switch (operation)
            {
                case Operation.Add:
                    {
                        return "Сложение";
                    }
                case Operation.Subtract:
                    {
                        return "Вычитание";
                    }
                case Operation.Multiply:
                    {
                        return "Умножение";
                    }
                case Operation.Divide:
                    {
                        return "Деление";
                    }
                default:
                    {
                        return "Не поддерживаемая операция";
                    }
            }
        }
        public static void PrintAvailableOperations()
        {
            Console.WriteLine("Доступные операции");
            foreach (var operation in operationMap)
            {
                Console.WriteLine($"{operation.Key} - {GetOperationDescription(operation.Value)}");
            }
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
        public static bool AskToContinue()
        {
            Console.WriteLine("Хотите выполнить еще операцию? Нажмите enter для продолжения или любую другую клавишу для выхода");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void DisplayCalculationResult(double a, double b, char operation, double result)
        {
            Console.WriteLine($"\nРезультат: {a} {operation} {b} = {result}");
        }
    }
}
