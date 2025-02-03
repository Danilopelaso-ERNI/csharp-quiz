using System;
using Serilog;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                Log.Information("Application started.");

                Console.WriteLine("Enter the first number:");
                double num1 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter the second number:");
                double num2 = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Enter the operation (add, subtract, multiply, divide):");
                string operation = Console.ReadLine()?.ToLower() ?? string.Empty;

                var calculator = new Calculator();    

                double result = calculator.PerformOperation(num1, num2, operation);
                Console.WriteLine($"The result is: {result}");

                Log.Information("Performed operation: {Operation} on {Num1} and {Num2}. Result: {Result}", operation, num1, num2, result);
            }
            catch (FormatException)
            {
                Log.Error("Invalid input. Please enter numeric values.");
                Console.WriteLine("Invalid input. Please enter numeric values.");
            }
            catch (DivideByZeroException)
            {
                Log.Error("Error: Cannot divide by zero.");
                Console.WriteLine("Error: Cannot divide by zero.");
            }
            catch (InvalidOperationException ex)
            {
                Log.Error("An error occurred: {Message}", ex.Message);
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            catch (Exception ex)
            {
                Log.Error("An unexpected error occurred: {Message}", ex.Message);
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                Log.Information("Calculation attempt finished.");
                Log.CloseAndFlush(); 
            }
        }
    }
}