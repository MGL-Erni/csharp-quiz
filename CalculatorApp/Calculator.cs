using CalculatorApp.Exceptions;


namespace CalculatorApp
{
    /*
        AIDA:
        """
        Unit tests should primarily focus on testing individual units of code in isolation, typically at the class or method level. 
        The goal is to ensure that each unit of code works correctly on its own. 
        This means that unit tests should not generally test the driver code or the main application logic found in Program.cs.
        """

        This is why I chose to handle errors inside of the class itself.
        When this class is unit tested, the custom exceptions associated with it will trigger when corresponding error conditions are met.
     */

    public class Calculator
    {
        // CS0825 : The contextual keyword 'var' may only appear within a local variable declaration.
        // public double PerformOperation(var num1, double num2, string operation)
        public double PerformOperation(string input1, string input2, string operation)
        {
            double num1, num2;
            
            // if one of the inputs is not convertible to double, it is invalid
            try
            {
                num1 = Double.Parse(input1);
                num2 = Double.Parse(input2);

            }
            catch (FormatException)
            {
                throw new InvalidInputException("Invalid input. Please enter numeric values.");
            }

            if (operation == "add")
            {
                return num1 + num2;
            }
            else if (operation == "subtract")
            {
                return num1 - num2;

            }
            else if (operation == "multiply")
            {
                return num1 * num2;
            }
            else if (operation == "divide")
            {
                // if the divisor is a double but 0, by default it will not throw a DivideByZeroException on its own
                // hence a custom one was made
                if (num2 == 0)
                {
                    throw new DoubleDivisorIsZeroException("Cannot divide by zero.");
                }
                return num1 / num2;
            }
            else
            {
                // not add, subtract, multiply, nor divide
                throw new OperationNotSupportedException("An error occurred: The specified operation is not supported.");
            }
        }
    }
}
