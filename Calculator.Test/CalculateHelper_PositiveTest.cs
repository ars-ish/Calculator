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
    class CalculateHelper_PositiveTest
    {
        [TestCase ("1+2", 3)]
        [TestCase("1*2", 2)]
        [TestCase("4/2", 2)]
        [TestCase("1-2", -1)]
        [TestCase("2^3", 8)]
        public void OneOperation(string input, double result)
        {
            var calculationResult = CalculateHelper.Calculate(input);
            Assert.IsTrue(calculationResult.IsSuccess());
            Assert.AreEqual(result, calculationResult.Result);
        }

        [TestCase("1+2*2", 5)]
        [TestCase("2+2/2", 3)]
        [TestCase("1+2^3", 9)]
        [TestCase("3-1*2", 1)]
        [TestCase("10-6/2", 7)]
        [TestCase("10-2^3", 2)]
        [TestCase("2*2^3", 16)]
        [TestCase("16/2^3", 2)]
        public void TwoOperationWithDifferentPriority(string input, double result)
        {
            var calculationResult = CalculateHelper.Calculate(input);
            Assert.IsTrue(calculationResult.IsSuccess());
            Assert.AreEqual(result, calculationResult.Result);
        }

        [TestCase("(2*(1+2))", 6)]
        [TestCase("1+(2+3)", 6)]
        [TestCase("5-(1+2)", 2)]
        [TestCase("(1+2)-5", -2)]
        public void NotationWithBrackets(string input, double result)
        {
            var calculationResult = CalculateHelper.Calculate(input);
            Assert.IsTrue(calculationResult.IsSuccess());
            Assert.AreEqual(result, calculationResult.Result);
        }

        [TestCase("2+-3", -1)]
        [TestCase("-3+2", -1)]
        [TestCase("-(1+2)", -3), Ignore("непонятно как реализовывать унарный минус при обратной польской записи")]
        public void UnaryMinus(string input, double result)
        {
            var calculationResult = CalculateHelper.Calculate(input);
            Assert.IsTrue(calculationResult.IsSuccess());
            Assert.AreEqual(result, calculationResult.Result);
        }

        [TestCase("1.2*2", 2.4)]
        [TestCase("1,2*2", 2.4)]
        [TestCase("-1.2*2", -2.4)]
        public void DecimalFractions(string input, double result)
        {
            var calculationResult = CalculateHelper.Calculate(input);
            Assert.IsTrue(calculationResult.IsSuccess());
            Assert.AreEqual(result, calculationResult.Result);
        }

    }
}
