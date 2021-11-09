using System;
using Xunit;

namespace CalculatorLibrary.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void ShouldCreateCalculatorObject()
        {
            Calculator calculator = new Calculator();
            calculator.Finish();
        }

        [Theory]
        [InlineData(-1,1,"a")]
        [InlineData(0,-5648,"a")]
        [InlineData(-554.046,0.7678,"a")]
        public void ShouldReturnCorrectResultsForAdd(double value1, double value2, string value3)
        {
            double expected = value1 + value2;
            Calculator calculator = new Calculator();
            Assert.Equal(expected, calculator.DoOperation(value1, value2, value3));
            calculator.Finish();
        }

        [Theory]
        [InlineData(0, 0, "s")]
        [InlineData(0, -5648, "s")]
        [InlineData(-554.046, 0.7678, "s")]
        public void ShouldReturnCorrectResultsForSub(double value1, double value2, string value3)
        {
            double expected = value1 - value2;
            Calculator calculator = new Calculator();
            Assert.Equal(expected, calculator.DoOperation(value1, value2, value3));
            calculator.Finish();
        }

        [Theory]
        [InlineData(423, 69, "m")]
        [InlineData(0, -5648, "m")]
        [InlineData(-554.046, 0.7678, "m")]
        public void ShouldReturnCorrectResultsForTMul(double value1, double value2, string value3)
        {
            double expected = value1 * value2;
            Calculator calculator = new Calculator();
            Assert.Equal(expected, calculator.DoOperation(value1, value2, value3));
            calculator.Finish();
        }

        [Theory]
        [InlineData(0, -4563, "d")]
        [InlineData(0, -5648, "d")]
        [InlineData(-554.046, 0.7678, "d")]
        public void ShouldReturnCorrectResultsForDiv(double value1, double value2, string value3)
        {
            double expected = value1 / value2;
            Calculator calculator = new Calculator();
            Assert.Equal(expected, calculator.DoOperation(value1, value2, value3));
            calculator.Finish();
        }

        [Theory]
        [InlineData(5, 0, "d")]
        public void ShouldReturnCorrectResultsForDivByZero(double value1, double value2, string value3)
        {
            Calculator calculator = new Calculator();
            Assert.Throws<DivideByZeroException>(() => calculator.DoOperation(value1, value2, value3)); 
            calculator.Finish();
        }
    }
}
