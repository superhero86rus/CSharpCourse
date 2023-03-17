using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1;
using ConsoleApp1.DAL;

namespace TestConsoleApp1
{
    class FakeDBContext : IDBContext
    {
        public IEnumerable<Student> AllStudents
        {
            get
            {
                // Множество объектов Student
                yield return new Student() { FirstName = "Sergey", LastName = "ABC" };
                yield return new Student() { FirstName = "Andrey", LastName = "CDE" };
                yield return new Student() { FirstName = "Sergey", LastName = "DEF" };
            }
        }
    }
}
