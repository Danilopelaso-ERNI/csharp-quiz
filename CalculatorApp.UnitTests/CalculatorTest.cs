using NUnit.Framework;

namespace CalculatorApp.UnitTests
{
    [TestFixture]
    public class CalculatorTest
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void PerformOperation_Addition_ReturnsCorrectResult()
        {
            double num1 = 10;
            double num2 = 5;
            string operation = "add";

            double result = _calculator.PerformOperation(num1, num2, operation);

            Assert.That(result, Is.EqualTo(15));
        }

        [Test]
        public void PerformOperation_Subtraction_ReturnsCorrectResult()
        {
            double num1 = 10;
            double num2 = 5;
            string operation = "subtract";

            double result = _calculator.PerformOperation(num1, num2, operation);

            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void PerformOperation_Multiplication_ReturnsCorrectResult()
        {
            double num1 = 10;
            double num2 = 5;
            string operation = "multiply";

            double result = _calculator.PerformOperation(num1, num2, operation);

            Assert.That(result, Is.EqualTo(50));
        }

        [Test]
        public void PerformOperation_Division_ReturnsCorrectResult()
        {
            double num1 = 10;
            double num2 = 2;
            string operation = "divide";

            double result = _calculator.PerformOperation(num1, num2, operation);

            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void PerformOperation_Division_ByZero_ThrowsDivideByZeroException()
        {
            double num1 = 10;
            double num2 = 0;
            string operation = "divide";

            var ex = Assert.Throws<DivideByZeroException>(() => _calculator.PerformOperation(num1, num2, operation));
            Assert.That(ex.Message, Is.EqualTo("Cannot divide by zero"));
        }

        [Test]
        public void PerformOperation_UnsupportedOperation_ThrowsInvalidOperationException()
        {
            double num1 = 10;
            double num2 = 5;
            string operation = "modulo"; 

            var ex = Assert.Throws<InvalidOperationException>(() => _calculator.PerformOperation(num1, num2, operation));
            Assert.That(ex.Message, Is.EqualTo("The specified operation is not supported."));
        }
    }
}