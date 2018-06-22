using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(5, 8);

            //Assert
            Assert.AreEqual(13, result);

        }
    }
}
