class Program
{
    static void Main(string[] args)
    {
        RunCalculator();
    }

    static void RunCalculator()
    {
        bool continueCalculation = true;

        while (continueCalculation)
        {
            try
            {
                double firstNumber = GetNumberFromUser("Введите первое число:");
                char operationInput = GetOperationFromUser();
                double secondNumber = GetNumberFromUser("Введите второе число:");

                double result = Calculate(firstNumber, secondNumber, operationInput);
                DisplayCalculationResult(firstNumber, secondNumber, operationInput, result);
            }
            catch (Exception ex)
            {
                DisplayError($"Произошла ошибка: {ex.Message}");
            }

            continueCalculation = AskToContinue();
        }
    }

    static bool AskToContinue()
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

    static string GetInputFromUser(string prompt)
    {
        Console.WriteLine(prompt);
        string input = Console.ReadLine();

        if (input == null)
        {
            throw new ArgumentException("Ошибка: Ввод не может быть пустым.");
        }

        return input;
    }

    static double GetNumberFromUser(string prompt)
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
                DisplayError(ex.Message);
            }
        }
    }

    static double ParseNumber(string input)
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

    static void PrintAvailableOperations()
    {
        Console.WriteLine("\nДоступные операции:");
        Console.WriteLine("+ - Сложение");
        Console.WriteLine("- - Вычитание");
        Console.WriteLine("* - Умножение");
        Console.WriteLine("/ - Деление");
    }

    static char GetOperationFromUser()
    {
        while (true)
        {
            try
            {
                PrintAvailableOperations();
                string input = GetInputFromUser("Выберите операцию:");
                return ValidateAndParseOperation(input);
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }
    }

    static char ValidateAndParseOperation(string input)
    {
        if (input.Length != 1)
        {
            throw new ArgumentException("Ошибка: Введите ровно один символ операции.");
        }

        char operation = input[0];
        if (operation == '+' || operation == '-' || operation == '*' || operation == '/')
        {
            return operation;
        }
        else
        {
            throw new ArgumentException("Ошибка: Неподдерживаемая операция.");
        }
    }

    static double Add(double a, double b)
    {
        return a + b;
    }

    static double Subtract(double a, double b)
    {
        return a - b;
    }

    static double Multiply(double a, double b)
    {
        return a * b;
    }

    static double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Ошибка: Деление на ноль");
        }
        return a / b;
    }

    static double Calculate(double a, double b, char operation)
    {
        double result;

        switch (operation)
        {
            case '+':
                result = Add(a, b);
                break;
            case '-':
                result = Subtract(a, b);
                break;
            case '*':
                result = Multiply(a, b);
                break;
            case '/':
                result = Divide(a, b);
                break;
            default:
                throw new InvalidOperationException($"Ошибка: Операция '{operation}' не поддерживается.");
        }
        return result;
    }

    static void DisplayCalculationResult(double a, double b, char operation, double result)
    {
        Console.WriteLine($"\nРезультат: {a} {operation} {b} = {result}");
    }

    static void DisplayError(string message)
    {
        Console.WriteLine(message);
    }
}