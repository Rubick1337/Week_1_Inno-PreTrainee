using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1_week_1
{
    public class InputValidator
    {
        public static string GetInputFromUser(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();

            if (input == null)
            {
                throw new ArgumentException("Ошибка: Ввод не может быть пустым.");
            }

            return input;
        }

        public static double GetNumberFromUser(string prompt)
        {
            while (true)
            {
                try
                {
                    string input = GetInputFromUser(prompt);
                    return ParseNumber(input);
                }
                catch (Exception ex)
                {
                    ErrorHandler.DisplayError(ex.Message);
                }
            }
        }

       private static double ParseNumber(string input)
        {
            input = input.Replace('.', ',');

            if (double.TryParse(input, out double number))
            {
                return number;
            }
            else
            {
                throw new FormatException("Ошибка: Введите корректное число.");
            }
        }

        public static char GetOperationFromUser(char[] operations)
        {
            while (true)
            {
                try
                {
                    string input = GetInputFromUser("Выберите операцию:");
                    return ValidateAndParseOperation(input,operations);
                }
                catch (Exception ex)
                {
                    ErrorHandler.DisplayError(ex.Message);
                }
            }
        }

        private static char ValidateAndParseOperation(string input, char[] operations)
        {
            if (input.Length != 1)
            {
                throw new ArgumentException("Ошибка: Введите ровно один символ операции.");
            }

            char operation = input[0];
            if (Array.Exists(operations,op => op == operation))
            {
                return operation;
            }
            else
            {
                throw new ArgumentException("Ошибка: Неподдерживаемая операция.");
            }
        }
    }
}
