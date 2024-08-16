namespace CalculatorApp;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the first number:");
        string num1 = Console.ReadLine();

        Console.WriteLine("Enter the second number:");
        string num2 = Console.ReadLine();

        Console.WriteLine("Enter the operation (add, subtract, multiply, divide):");
        string operation = Console.ReadLine()?.ToLower() ?? string.Empty;

        var calculator = new Calculator();    
        double result = calculator.PerformOperation(num1, num2, operation);
        Console.WriteLine($"The result is: {result}");

        Console.WriteLine("Calculation attempt finished.");
    }
}