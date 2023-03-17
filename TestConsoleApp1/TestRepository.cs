using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ConsoleApp1.DAL;

namespace TestConsoleApp1
{
    [TestClass]
    public class TestRepository
    {
        [TestMethod]
        public void TestGetStudentsByName()
        {
            IRepository rep = new Repository(new FakeDBContext());
            int count = rep.GetStudentsByName("Sergey").Count;
            Assert.AreEqual<int>(2, count);
        }
    }
}
