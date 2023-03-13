using System;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Excel;

namespace CSharpCourse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // Используя var и оператор new, можем не указывать тип слева 
            var address = new StringBuilder();
            address.Append("Московская область");
            address.Append(", Ленинский район");
            address.Append(", рп Боброво");

            string fullAddress = address.ToString();

            Console.WriteLine(fullAddress);

            // Тестирование регулярки
            var textToTest = "hell0 w0rld";
            var regEx = "\\d";

            var result = Regex.IsMatch(textToTest, regEx, RegexOptions.None);
            if (result) Console.WriteLine("Строка подходит!");

            // switch expression
            // C# 8 version (DotNet Core 3+)
            /*
            int x = 2;
            string s = x switch
            {
                1 => "один",
                2 => "два",
                3 => "три"
            };
            */

            // Массивы в C# неизменного размера
            int[] arr = new int[10];
            Console.WriteLine(arr.Length);

            int[,] matrix =
            {
                {1, 2, 3},
                {2, 4, 5},
                {8, 9, 7}
            };

            // Рваный массив
            int[][] jagged =
            {
                new int[]{1,2,3},
                new int[]{4,5}
            };

            Console.WriteLine(matrix.Rank);
            Console.WriteLine(jagged.Rank);

            // Оператор ??
            string w = "Сергей";
            Console.WriteLine( ((w==null) ? "" : w ).ToUpper() );
            Console.WriteLine((w ?? "").ToUpper());

            // nullable тип, т.е. переменная может быть как int, так и null
            int? t = null;
            if (t.HasValue)
            {
                int k = t.Value;
            }

            // namespace - группировка областей
            //System.IO.File f;
            //System.Collections.Generic.List l;

            /*
            using System.IO.File;
            using SCG = System.Collections.Generic; // ALIAS работает только в текущем файле
            */

            // COM
            // Подключили через NuGet - Microsoft.Office.Interop.Excel
            Application excel = new Application();
            excel.Visible = true;

            // REF
            int x1 = 11;
            int x2 = 22;

            testValue(x1);
            testRef(ref x2);

            Console.WriteLine(x1 + " | " + x2); // 11 | 23

            Console.ReadKey();
        }

        public static void testValue(int x)
        {
            x = 12;
        }

        public static void testRef(ref int x)
        {
            x = 23;
        }

    }
}
