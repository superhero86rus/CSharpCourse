using System;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace CSharpCourse
{
    class Program
    {
        static void Main(string[] args)
        {
            // Day1();

            Day2();

            Console.ReadKey();
        }

        // Тесты первого дня
        public static void Day1()
        {
            Debug.WriteLine("Starting Application!");

            if (!EventLog.SourceExists("My app"))
                EventLog.CreateEventSource("My app", "Application");

            EventLog.WriteEntry("My app", "My message");

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
            Console.WriteLine(((w == null) ? "" : w).ToUpper());
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

            // Вспомогательные функции
            // Два вида описания функции
            void testValue(int x) => x = 12;

            void testRef(ref int x)
            {
                x = 23;
            }
        }

        enum Colors { Red, Green, Blue }

        // Структура - value type
        // Класс - reference type
        struct Money
        {
            public decimal Summa;
            public string Currency;

            // Не обязательный Конструктор
            // Все поля структуры Обязательно должны быть проинициализированы
            
            public Money(decimal Summa, string Currency)
            {
                this.Summa = Summa;
                this.Currency = Currency;
            }

            public void Show() => Console.WriteLine(Summa + " " + Currency);
        }

        // Тесты второго дня
        public static void Day2()
        {
            Colors c = Colors.Green;

            int k = (int)c;

            Console.WriteLine("Color int value: " + k);

            // Структура
            Money m1;

            m1.Summa = 100;
            m1.Currency = "рублей";

            Money m2 = m1; // Скопировали структуру. Структура m2 не зависит от m1 и не изменяет его
            m1.Currency = "долларов";

            m1.Show();
            m2.Show();

            // Инициализация с вызовом конструктора
            Money m3 = new Money(200, "USD");
            m3.Show();
        }
        
    }
}
