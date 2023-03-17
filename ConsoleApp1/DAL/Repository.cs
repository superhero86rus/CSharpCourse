using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DAL
{
    public class Repository : IRepository, IDisposable
    {
        private IDBContext db;

        public Repository()
        {
            db = new SchoolDB();
        }

        public Repository(IDBContext db)
        {
            this.db = db;
        }

        public void Dispose()
        {
            if(db is IDisposable) (db as IDisposable).Dispose();
        }
        
        public IList<Student> GetStudentsByAge(int minAge)
        {
            // LINQ запрос
            return null;
        }

        public IList<Student> GetStudentsByName(string name)
        {
            // LINQ запрос
            /*
            return (
                from s in db.AllStudents
                where s.FirstName.Contains(name)
                select s
            ).ToList();
            */

            // Procedure style
            return db.AllStudents
                    .Where(s => s.FirstName.Contains(name))
                    .Select(s => s)
                    .ToList();
        }
    }
}
