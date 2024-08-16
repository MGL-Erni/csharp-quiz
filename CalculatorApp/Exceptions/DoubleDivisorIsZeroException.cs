namespace CalculatorApp.Exceptions
{
    public class DoubleDivisorIsZeroException : Exception
    {
        public DoubleDivisorIsZeroException()
        {
        }

        public DoubleDivisorIsZeroException(string message)
            : base(message)
        {
        }

        public DoubleDivisorIsZeroException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}