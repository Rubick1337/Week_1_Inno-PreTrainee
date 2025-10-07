using Task_1_week_1;

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
                double firstNumber = InputValidator.GetNumberFromUser("Введите первое число:");
                Calculator.PrintAvailableOperations();
                char operationInput = InputValidator.GetOperationFromUser();
                double secondNumber = InputValidator.GetNumberFromUser("Введите второе число:");
                double result = Calculator.Calculate(firstNumber, secondNumber, operationInput);
                Calculator.DisplayCalculationResult(firstNumber, secondNumber, operationInput, result);
            }
            catch (Exception ex)
            {
                ErrorHandler.DisplayError($"Произошла ошибка: {ex.Message}");
            }

            continueCalculation = Calculator.AskToContinue();
        }
    }

}