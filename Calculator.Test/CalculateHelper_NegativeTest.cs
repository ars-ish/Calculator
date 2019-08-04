using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Calculator.Library;

namespace Calculator.Test
{
    [TestFixture]
    class CalculateHelper_NegativeTest
    {
        [TestCase("wdWawdi1+a2", "Incorrect symbols")]
        [TestCase("ШЩзо1ч+24ф", "Incorrect symbols")]
        [TestCase("_1+%22#", "Incorrect symbols")]
        [TestCase("1/n+/r/t2", "Incorrect symbols")]
        public void IncorrectSymbols(string input, string error)
        {
            var result = CalculateHelper.Calculate(input);
            Assert.IsFalse(result.IsSuccess());
            Assert.AreEqual(error, result.Error);
        }


        [TestCase(")1+2)", "Invalid notation")]
        [TestCase("(1+2", "Invalid notation")]
        [TestCase("1+2)", "Invalid notation")]
        [TestCase("1(+)2", "Invalid notation")]
        public void InvalidBrackets(string input, string error)
        {
            var result = CalculateHelper.Calculate(input);
            Assert.IsFalse(result.IsSuccess());
            Assert.AreEqual(error, result.Error);
        }

        [TestCase("1++", "Invalid notation")]
        [TestCase("1+", "Invalid notation")]
        [TestCase("-+1", "Invalid notation")]
        [TestCase("+", "Invalid notation")]
        public void MisuseOfOperator(string input, string error)
        {
            var result = CalculateHelper.Calculate(input);
            Assert.IsFalse(result.IsSuccess());
            Assert.AreEqual(error, result.Error);
        }

        [TestCase("1/0", "Division by zero")]
        [TestCase("1/(1-1)", "Division by zero")]
        public void DivisionByZero(string input, string error)
        {
            var result = CalculateHelper.Calculate(input);
            Assert.IsFalse(result.IsSuccess());
            Assert.AreEqual(error, result.Error);
        }
    }
}
