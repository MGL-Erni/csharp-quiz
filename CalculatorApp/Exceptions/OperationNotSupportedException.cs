namespace CalculatorApp.Exceptions
{
    public class OperationNotSupportedException : Exception
    {
        public OperationNotSupportedException()
        {
        }

        public OperationNotSupportedException(string message)
            : base(message)
        {
        }

        public OperationNotSupportedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
