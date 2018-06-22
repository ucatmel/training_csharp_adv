using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Calc_Sum_5_and_8_Result_13()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(5, 8);

            //Assert
            Assert.AreEqual(13, result);

        }

        [TestMethod]
        public void Calc_Sum_0_and_0_Result_0()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(0, 0);

            //Assert
            Assert.AreEqual(0, result);

        }

        [TestMethod]
        public void Calc_Sum_MAX_and_1_Result____()
        {
            //Arrange
            Calc calc = new Calc();

            //Act & Assert

            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MaxValue, 1));

        }
    }
}
