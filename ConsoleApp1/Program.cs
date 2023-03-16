using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }

    public static class StringExt
    {
        // extension method - добавляем this
        public static string Capitalize(this string s)
        {
            string[] words = s.Split(' ');
            StringBuilder sb = new StringBuilder();

            foreach (string w in words)
            {
                if (w.Length > 0)
                    sb.Append(char.ToUpper(w[0])).Append(w.Substring(1)).Append(' ');
            }

            return sb.ToString().TrimEnd();
        }
    }
}
