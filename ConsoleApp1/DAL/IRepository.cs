﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.DAL
{
    public interface IRepository
    {
        IList<Student> GetStudentsByAge(int minAge);
        IList<Student> GetStudentsByName(string name);
    }
}
