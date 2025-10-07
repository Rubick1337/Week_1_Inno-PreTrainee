using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Task_1_week_1.Calculator;

namespace Task_1_week_1
{
    public class CalculatorUI
    {
        public static void PrintAvailableOperations()
        {
            Console.WriteLine("Доступные операции");
            foreach (var symbol in Calculator.GetAvailableOperationSymbols())
            {
                var operation = GetOperationFromSymbol(symbol);
                Console.WriteLine($"{symbol} - {GetOperationDescription(operation)}");
            }
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
