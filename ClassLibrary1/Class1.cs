using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CalculatorLibrary;

namespace ConsoleApp6
{
    [TestFixture]
    class TestCase
    {
        [Test]
        public void OnlyAddition()
        {
            Assert.AreEqual(3, Calculator.Calculate("1+2"));
        }

        [Test]
        public void OnlySubtraction()
        {
            Assert.AreEqual(1, Calculator.Calculate("3-2"));
        }

        [Test]
        public void OnlyMultiplication()
        {
            Assert.AreEqual(6, Calculator.Calculate("3*2"));
        }

        [Test]
        public void OnlyExponentiation()
        {
            Assert.AreEqual(8, Calculator.Calculate("2^3"));
        }

        [Test]
        public void AdditionAndMultiplication()
        {
            Assert.AreEqual(7, Calculator.Calculate("1+2*3"));
        }

        [Test]
        public void AdditionAndDivision()
        {
            Assert.AreEqual(3, Calculator.Calculate("1+4/2"));
        }

        [Test]
        public void SubtractionAndMiltiplication()
        {
            Assert.AreEqual(3, Calculator.Calculate("5-1*2"));
        }

        [Test]
        public void SubtractionAndDivision()
        {
            Assert.AreEqual(3, Calculator.Calculate("5-4/2"));
        }

        [Test]
        public void ExponentiationAndMultiplication()
        {
            Assert.AreEqual(16, Calculator.Calculate("2*2^3"));
        }

        [Test]
        public void NotationWithBranchedLowPriorityOperation()
        {
            Assert.AreEqual(9, Calculator.Calculate("(1+2)*3"));
        }

        [Test]
        public void DivisionByZero()
        {
            Assert.AreEqual(Double.PositiveInfinity, Calculator.Calculate("2/0"));
        }

        [Test]
        public void NotationWithNegativeNumber()
        {
            Assert.AreEqual(-1, Calculator.Calculate("2+-3"));
        }

        [Test]
        public void NegativeNumberInBeginningOfNotation()
        {
            Assert.AreEqual(-1, Calculator.Calculate("-3+2"));
        }

        [Test]
        public void MinusBeforBranch()
        {
            Assert.AreEqual(2, Calculator.Calculate("5-(1+2)"));
        }

        [Test]
        public void MinusAfterBranch()
        {
            Assert.AreEqual(-2, Calculator.Calculate("(1+2)-5"));
        }

        [Test]
        public void FloatNumbersWithDot()
        {
            Assert.AreEqual(2.2, Calculator.Calculate("1.1*2"));
        }

        [Test]
        public void FloatNumbersWithComma()
        {
            Assert.AreEqual(2.2, Calculator.Calculate("1,1*2"));
        }

        [Test]
        public void NotationWithSpaces()
        {
            Assert.AreEqual(3, Calculator.Calculate(" 1   + 2  "));
        }
    }
}
