using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ConsoleApp1;

namespace TestConsoleApp1
{
    [TestClass]
    public class TestStringExt
    {
        /*
        // Специальные атрибуты для тестирования
        [TestInitialize]
        [TestCleanup]

        [ClassInitialize]
        [ClassCleanup]
        */

        [TestMethod]
        public void TestCapitalize()
        {
            string s = "hello alexandr!";
            string r = StringExt.Capitalize(s);

            Assert.AreEqual<string>("Hello Alexandr!", r);
        }
    }
}
