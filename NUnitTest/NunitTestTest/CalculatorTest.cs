using System;
using NUnit.Framework;
using NUnitTest;

namespace NunitTestTest
{
    [TestFixture]
    public class CalculatorTest
    {
        [Test]
        public void TestAdd()
        {
            Calculator cal = new Calculator();
            int expected = 5;
            int actual = cal.Add(2, 3);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestDivide()
        {
            Calculator cal = new Calculator();
            int expected = 5;
            int actual = cal.Divide(25, 0);
            Assert.AreEqual(expected, actual);
        }
    }
}