using System;
using Xunit;
using CalculatorProgram;
using System.Threading;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace CalculatorLibrary.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void ShouldCreateCalculatorObject()
        {
            Calculator calculator = new Calculator();
            Assert.NotNull(calculator);
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
            Assert.Throws<Newtonsoft.Json.JsonWriterException>(() => calculator.DoOperation(value1, value2, value3)); 
            calculator.Finish();
        }

        [Fact]
        public void ShouldBeAbleToCreateProgramObject()
        {
            Program program = new Program();
            Assert.NotNull(program);
        }


        [Fact]
        public void ShouldBeAbleToRunProgramMain()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            var output = new StringWriter();
            Console.SetOut(output);
            var input = new StringReader("156.15" + Environment.NewLine + "-6548.0012" + Environment.NewLine + "d" + Environment.NewLine + "n");
            Console.SetIn(input);

            Program.Main(new string[] { });

            var expectedOutput = "Console Calculator in C#" +
                                 "------------------------" +
                                 "Type a number, and then press Enter: " +
                                 "Type another number, and then press Enter: " +
                                 "Choose an operator from the following list:" +
                                 "a - Add" +
                                 "s - Subtract" +
                                 "m - Multiply" +
                                 "d - Divide" +
                                 "Your option? " +
                                 "Your result: -0.02" +
                                 "------------------------" +
                                 "Press 'n' and Enter to close the app, or press any other key and Enter to continue: ";

            Assert.Equal(expectedOutput, Regex.Replace(output.ToString(), @"[\r\t\n]+", string.Empty));
        }
    }
}
