using NUnit.Framework;
using CalculatorApp.Exceptions;

namespace CalculatorApp.UnitTests
{
    internal class CalculatorTest
    {
        protected Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        /*
        [Test]
        public void MethodUnderTest_Scenario_ExpectedBehavior()
        {
            Assert.Pass();
        }
        */

        /*** happy path ***/

        [Test]
        public void PerformOperation_Addition_Num1PlusNum2()
        {
            // Assert.AreEqual(expected, actual)
            //Assert.AreEqual(_calculator.PerformOperation(1, 1, "add"), 2);

            // VS complaint: NUnit2005
            // Consider using the constraint model, Assert.That(actual, Is.EqualTo(expected)), instead of the classic model, ClassicAssert.AreEqual(expected, actual).
            // The classic Assert model, ClassicAssert.AreEqual(expected, actual), makes it easy to mix the expected and the actual parameter, so this analyzer marks usages of ClassicAssert.AreEqual from the classic Assert model.
            // src: https://github.com/nunit/nunit.analyzers/blob/master/documentation/NUnit2005.md

            Assert.That(_calculator.PerformOperation("1", "1", "add"), Is.EqualTo((double)2));
            Assert.That(_calculator.PerformOperation("2", "10", "add"), Is.EqualTo((double)12));
            Assert.That(_calculator.PerformOperation("-1", "1", "add"), Is.EqualTo((double)0));
            Assert.That(_calculator.PerformOperation("-4", "3", "add"), Is.EqualTo((double)-1));
        }

        [Test]
        public void PerformOperation_Subtraction_Num1MinusNum2()
        {
            Assert.That(_calculator.PerformOperation("5", "3", "subtract"), Is.EqualTo((double)2));
            Assert.That(_calculator.PerformOperation("10", "2", "subtract"), Is.EqualTo((double)8));
            Assert.That(_calculator.PerformOperation("1", "1", "subtract"), Is.EqualTo((double)0));
            Assert.That(_calculator.PerformOperation("3", "4", "subtract"), Is.EqualTo((double)-1));
        }

        [Test]
        public void PerformOperation_Multiplication_Num1TimesNum2()
        {
            Assert.That(_calculator.PerformOperation("5", "3", "multiply"), Is.EqualTo((double)15));
            Assert.That(_calculator.PerformOperation("10", "2", "multiply"), Is.EqualTo((double)20));
            Assert.That(_calculator.PerformOperation("1", "1", "multiply"), Is.EqualTo((double)1));
            Assert.That(_calculator.PerformOperation("3", "4", "multiply"), Is.EqualTo((double)12));
        }

        [Test]
        public void PerformOperation_Division_Num1OverNum2()
        {
            Assert.That(_calculator.PerformOperation("6", "3", "divide"), Is.EqualTo((double)2));
            Assert.That(_calculator.PerformOperation("10", "2", "divide"), Is.EqualTo((double)5));
            Assert.That(_calculator.PerformOperation("1", "1", "divide"), Is.EqualTo((double)1));
            Assert.That(_calculator.PerformOperation("12", "4", "divide"), Is.EqualTo((double)3));
        }

        /*** exception handling ***/

        [Test]
        public void PerformOperation_OperationNotSupported_NotImplementedException()
        {
            Assert.Throws<OperationNotSupportedException>(() => _calculator.PerformOperation("2", "2", "aaaaa"));
        }

        [Test]
        public void PerformOperation_InvalidInputNonNumeric_FormatException()
        {
            Assert.Throws<FormatException>(() => _calculator.PerformOperation("aaaaaa", "2", "add"));
            Assert.Throws<FormatException>(() => _calculator.PerformOperation("12", "bbbb", "multiply"));
        }

        [Test]
        public void PerformOperation_DivideByZero_DoubleDivisorIsZero()
        {
            Assert.Throws<DoubleDivisorIsZeroException>(() => _calculator.PerformOperation("-1", "0", "divide"));
            Assert.Throws<DoubleDivisorIsZeroException>(() => _calculator.PerformOperation("1", "0", "divide"));
            Assert.Throws<DoubleDivisorIsZeroException>(() => _calculator.PerformOperation("0", "0", "divide"));
        }

        []

        /*** for unhandled unknown exceptions, i have chosen to allow the program to crash; for easier debugging when the need arises ***/
    }
}
