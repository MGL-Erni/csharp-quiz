using NUnit.Framework;

namespace CalculatorApp.UnitTests;

[TestFixture]
public class CalculatorTest
{
    /*
    [Test]
    public void MethodUnderTest_Scenario_ExpectedBehavior()
    {
        Assert.Pass();
    }
    */

    private Calculator _calculator;

    [SetUp]
    public void Setup()
    {
        _calculator = new Calculator();
    }

    /*** happy path ***/

    [Test]
    public void PerformOperation_Addition_Num1PlusNum2()
    {
        // Assert.AreEqual(expected, actual)
        //Assert.AreEqual(_calculator.PerformOperation(1, 1, "+"), 2);

        // VS complaint: NUnit2005
        // Consider using the constraint model, Assert.That(actual, Is.EqualTo(expected)), instead of the classic model, ClassicAssert.AreEqual(expected, actual).
        // The classic Assert model, ClassicAssert.AreEqual(expected, actual), makes it easy to mix the expected and the actual parameter, so this analyzer marks usages of ClassicAssert.AreEqual from the classic Assert model.
        // src: https://github.com/nunit/nunit.analyzers/blob/master/documentation/NUnit2005.md

        Assert.That(_calculator.PerformOperation(1, 1, "+"), Is.EqualTo((double)2));
        Assert.That(_calculator.PerformOperation(2, 10, "+"), Is.EqualTo((double)12));
        Assert.That(_calculator.PerformOperation(-1, 1, "+"), Is.EqualTo((double)0));
        Assert.That(_calculator.PerformOperation(-4, 3, "+"), Is.EqualTo((double)-1));
    }

    [Test]
    public void PerformOperation_Subtraction_Num1MinusNum2()
    {
        Assert.That(_calculator.PerformOperation(5, 3, "-"), Is.EqualTo((double)2));
        Assert.That(_calculator.PerformOperation(10, 2, "-"), Is.EqualTo((double)8));
        Assert.That(_calculator.PerformOperation(1, 1, "-"), Is.EqualTo((double)0));
        Assert.That(_calculator.PerformOperation(3, 4, "-"), Is.EqualTo((double)-1));
    }

    [Test]
    public void PerformOperation_Multiplication_Num1TimesNum2()
    {
        Assert.That(_calculator.PerformOperation(5, 3, "*"), Is.EqualTo((double)15));
        Assert.That(_calculator.PerformOperation(10, 2, "*"), Is.EqualTo((double)20));
        Assert.That(_calculator.PerformOperation(1, 1, "*"), Is.EqualTo((double)1));
        Assert.That(_calculator.PerformOperation(3, 4, "*"), Is.EqualTo((double)12));
    }

    [Test]
    public void PerformOperation_Division_Num1OverNum2()
    {
        Assert.That(_calculator.PerformOperation(6, 3, "/"), Is.EqualTo((double)2));
        Assert.That(_calculator.PerformOperation(10, 2, "/"), Is.EqualTo((double)5));
        Assert.That(_calculator.PerformOperation(1, 1, "/"), Is.EqualTo((double)1));
        Assert.That(_calculator.PerformOperation(12, 4, "/"), Is.EqualTo((double)3));

        // Additional test for division by zero to ensure proper handling
        Assert.Throws<DivideByZeroException>(() => _calculator.PerformOperation(5, 0, "/"));
    }

    /*** invalid inputs ***/
    [Test]
    public void PerformOperation_InvalidOperator_ThrowsInvalidOperationException()
    {
        Assert.Throws<InvalidOperationException>(() => _calculator.PerformOperation(5, 3, "%"));
        Assert.Throws<InvalidOperationException>(() => _calculator.PerformOperation(10, 2, "&"));
        Assert.Throws<InvalidOperationException>(() => _calculator.PerformOperation(1, 1, "^"));
    }

    [Test]
    public void PerformOperation_NonNumericInputs_ThrowsFormatException()
    {
        // Assuming the calculator method is overloaded to accept strings and convert them to numbers
        Assert.Throws<FormatException>(() => _calculator.PerformOperation("five", "three", "+"));
        Assert.Throws<FormatException>(() => _calculator.PerformOperation("ten", "two", "-"));
        Assert.Throws<FormatException>(() => _calculator.PerformOperation("one", "one", "*"));
    }

    [Test]
    public void PerformOperation_NullInputs_ThrowsArgumentNullException()
    {
        // Assuming the calculator method is overloaded to accept nullable types
        Assert.Throws<ArgumentNullException>(() => _calculator.PerformOperation(null, 3, "+"));
        Assert.Throws<ArgumentNullException>(() => _calculator.PerformOperation(5, null, "-"));
        Assert.Throws<ArgumentNullException>(() => _calculator.PerformOperation(null, null, "*"));
    }

    [Test]
    public void PerformOperation_EmptyOperator_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => _calculator.PerformOperation(5, 3, ""));
        Assert.Throws<ArgumentException>(() => _calculator.PerformOperation(10, 2, " "));
    }

    /*** edge cases besides divide by 0 ***/

    [Test]
    public void PerformOperation_DivideByOne_Unchanged()
    {
        Assert.That(_calculator.PerformOperation(5, 1, "/"), Is.EqualTo((double)5));
        Assert.That(_calculator.PerformOperation(10, 1, "/"), Is.EqualTo((double)10));
    }

    [Test]
    public void PerformOperation_MultiplyByOne_Unchanged()
    {
        Assert.That(_calculator.PerformOperation(5, 1, "*"), Is.EqualTo((double)5));
        Assert.That(_calculator.PerformOperation(10, 1, "*"), Is.EqualTo((double)10));
    }

    [Test]
    public void PerformOperation_MultiplyPosNeg_Neg()
    {
        Assert.That(_calculator.PerformOperation(5, -3, "*"), Is.EqualTo((double)-15));
        Assert.That(_calculator.PerformOperation(-10, 2, "*"), Is.EqualTo((double)-20));
    }

    [Test]
    public void PerformOperation_MultiplyNegNeg_Pos()
    {
        Assert.That(_calculator.PerformOperation(-5, -3, "*"), Is.EqualTo((double)15));
        Assert.That(_calculator.PerformOperation(-10, -2, "*"), Is.EqualTo((double)20));
    }

    [Test]
    public void PerformOperation_Divide_PosNeg_Neg()
    {
        Assert.That(_calculator.PerformOperation(6, -3, "/"), Is.EqualTo((double)-2));
        Assert.That(_calculator.PerformOperation(-10, 2, "/"), Is.EqualTo((double)-5));
    }

    [Test]
    public void PerformOperation_NegNeg_Pos()
    {
        Assert.That(_calculator.PerformOperation(-6, -3, "/"), Is.EqualTo((double)2));
        Assert.That(_calculator.PerformOperation(-10, -2, "/"), Is.EqualTo((double)5));
    }



