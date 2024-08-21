using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using System.Net;
using Microsoft.Extensions.DependencyInjection;
using CalculatorApp.Exceptions;

namespace CalculatorApp;

class Program
{
    static void Main(string[] args)
    {
        /*** setup logging via dependency injection ***/
        // Set up a service collection
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        // Build the service provider
        var serviceProvider = serviceCollection.BuildServiceProvider();
        // Get the logger instance for the current class (i.e. Program)
        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

        /*** main code ***/
        Console.WriteLine("Enter the first number:");
        string num1 = Console.ReadLine();

        Console.WriteLine("Enter the second number:");
        string num2 = Console.ReadLine();

        Console.WriteLine("Enter the operation (add, subtract, multiply, divide):");
        string operation = Console.ReadLine()?.ToLower() ?? string.Empty;

        var calculator = new Calculator();
        double? result = null;

        try
        {
            result = calculator.PerformOperation(num1, num2, operation);
        }
        catch (DoubleDivisorIsZeroException ex)
        {
            logger.LogError("Zero divisor was input.");
        }
        catch (InvalidInputException ex)
        {
            logger.LogError("Non-numerical input was entered for a number.");
        }
        catch (OperationNotSupportedException ex)
        {
            logger.LogError("Unsupported operation was entered.");
        }
        
        if (result != null)
        {
            Console.WriteLine($"The result is: {result}");
        }
        else
        {
            Console.WriteLine("An error occured while computing the result.");
        }
        
        Console.WriteLine("Calculation attempt finished.");
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Add logging services
        services.AddLogging(configure =>
        {
            configure.AddConsole();
            configure.SetMinimumLevel(LogLevel.Information);
        });
    }
}