using System.ComponentModel.Design;

namespace CalculatorApp;

/* THROW errors in OBJECTS / classes (e.g. Calculator). CATCH errors in DRIVING CODE (i.e. Program.cs) */

public class Calculator
{
    public double PerformOperation(double num1, double num2, string operation)
    {
        // Implements the PerformOperation method
        if (operation == "+")
        {
            return num1 + num2;
        }
        else if (operation == "-")
        { 
            return num1 - num2;
        }
        else if (operation == "*")
        {
            return num1 * num2;
        }
        else if (operation == "/")
        {
            return num1 / num2;
        }
        else
        {
            throw new NotImplementedException();
        }
    }
}