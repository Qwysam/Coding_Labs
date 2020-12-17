using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab7;
namespace Lab7Test
{
    [TestClass]
    public class RegeExTest
    {
        [TestMethod]
        public void CheckStringTrue()
        {
            Program p = new Program();
            string input = "BA8167AK";
            Assert.AreEqual(true,p.CheckString(input));
        }
        [TestMethod]
        public void CheckStringFalse()
        {
            Program p = new Program();
            string input = "BZ8167AK";
            Assert.AreEqual(false, p.CheckString(input));
        }
    }
}
