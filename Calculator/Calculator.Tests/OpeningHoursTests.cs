using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class OpeningHoursTests
    {
        [TestMethod]
        public void OpeningHours_isOpen()
        {
            OpeningHours oh = new OpeningHours();

            Assert.IsFalse(oh.IsOpen( new DateTime(1, 1, 1, 0, 0, 0)));
            Assert.IsFalse(oh.IsOpen( new DateTime(1, 1, 1, 10, 29, 0)));
            Assert.IsTrue(oh.IsOpen( new DateTime(1, 1, 1, 10, 30, 0)));
            Assert.IsTrue(oh.IsOpen( new DateTime(1, 1, 1,18, 59, 0)));
            Assert.IsFalse(oh.IsOpen(new DateTime(1, 1, 1, 19, 00, 0)));

        }

        [DataTestMethod]
        [DataRow(2018, 4, 2, 10, 30, true)]//mo
        [DataRow(2018, 4, 2, 10, 29, false)]//mo
        [DataRow(2018, 4, 2, 19, 0, false)] //mo
        [DataRow(2018, 4, 7, 12, 0, true)] //sa
        [DataRow(2018, 4, 7, 18, 0, false)] //sa
        [DataRow(2018, 4, 8, 12, 0, false)] //so
        public void OpeningHours__IsOpen_DataRow(int y, int M, int d, int h, int m, bool result)
        {
            var dt = new DateTime(y, M, d, h, m, 0);
            var oh = new OpeningHours();

            Assert.AreEqual(result, oh.IsOpen(dt));
        }
    }
}
