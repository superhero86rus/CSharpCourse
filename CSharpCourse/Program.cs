﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;

using System.Collections; // Нетипизированные коллекции
using System.Collections.Generic; // Типизированные коллекции
using System.Collections.Specialized; // Частично типизированные коллекции

using Newtonsoft.Json;

namespace CSharpCourse
{
    // Статический класс, который переводит первую букву слова в верхний регистр
    // Метод расширения может использоваться в классе верхнего уровня, поэтому этот класс пришлось вытащить изнутри класса Program
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

    public partial class Program
    {
        // Enumerator
        class MyE : IEnumerator<int>
        {
            private int k = 0;

            public int Current => k;
            /*
            // Что эквивалентно
            public int Current
            {
                get { return k; }
            }
            */

            object IEnumerator.Current => k;

            public void Dispose()
            {
                //throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                switch (k)
                {
                    case 0: k = 100; return true;
                    case 200: k = 200; return true;
                    case 300: k = 300; return true;
                    default: return false;
                }
            }

            public void Reset()
            {
                k = 0;
            }
        }

        class MyI : IEnumerable<int>
        {
            public IEnumerator<int> GetEnumerator()
            {
                return new MyE();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return new MyE();
            }
        }

        public static IEnumerable<int> GetInts3()
        {
            return new MyI();
        }

        static void Main(string[] args)
        {
            // Basic();
            // EnumStruct();
            // Collections();
            // Delegates();
            // ClassesConstructorDestructor();
            // StaticClasses();
            // Enumeration();

            FileSystem();

            Console.ReadKey();
        }

        // Тесты первого дня
        public static void Basic()
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
            private decimal summa;
            // Property
            public decimal Summa
            {
                get { return summa; }
                set { this.summa = value; }

            }

            // Автоматический Property. Это тоже самое, что выше. Используется, когда логики нет
            // public decimal Summa { get; set; }

            public string Currency { get; set; }

            // Не обязательный Конструктор
            // Все поля структуры Обязательно должны быть проинициализированы
            
            public Money(decimal Summa, string Currency)
            {
                this.summa = Summa;
                this.Currency = Currency;
            }

            public decimal getProcent()
            {
                return Summa * 0.13M; // M - дробное число типа decimal
            }

            public void setProcent(decimal procent)
            {
                this.Summa = this.Summa / procent;
            }

            public void Show() => Console.WriteLine(Summa + " " + Currency);
        }

        // Использование индексирующего Property
        struct Coords
        {
            public int X;
            public int Y;

            // Стандарт
            public int this[int index]
            {
                get
                {
                    switch (index)
                    {
                        case 0: return X;
                        case 1: return Y;
                        default: throw new IndexOutOfRangeException();
                    }
                }
                set
                {
                    switch (index)
                    {
                        case 0: X = value; break;
                        case 1: Y = value; break;
                        default: throw new IndexOutOfRangeException();
                    }
                }
            }

            // Строковое индексирующее Property
            public int this[string index]
            {
                get
                {
                    switch (char.ToUpper(index[0]))
                    {
                        case 'X': return X;
                        case 'Y': return Y;
                        default: throw new IndexOutOfRangeException();
                    }
                }
                set
                {
                    switch (char.ToUpper(index[0]))
                    {
                        case 'X': X = value; break;
                        case 'Y': Y = value; break;
                        default: throw new IndexOutOfRangeException();
                    }
                }
            }
        }

        // Тесты второго дня - перечисления, структуры, свойства
        public static void EnumStruct()
        {
            Colors c = Colors.Green;

            int k = (int)c;

            Console.WriteLine("Color int value: " + k);

            // Структура
            Money m1 = new Money(100, "рублей");

            /*
            m1.Summa = 100;
            m1.Currency = "рублей";
            m1.Procent = 0.13M;
            */

            Money m2 = m1; // Скопировали структуру. Структура m2 не зависит от m1 и не изменяет его
            m1.Currency = "долларов";

            m1.Show();
            m2.Show();

            // Инициализация с вызовом конструктора
            Money m3 = new Money(200, "USD");
            m3.Show();

            m1.setProcent(m1.getProcent() + 0.01M);
            Console.WriteLine("m1 Procent = " + m1.getProcent());

            Coords c1;
            c1.X = 100;
            c1.Y = 150;

            Console.WriteLine(c1.X + " : " + c1.Y);

            c1[0] = 200;
            c1[1] = 300;

            Console.WriteLine(c1.X + " : " + c1.Y);

            c1["X"] = 250;
            c1["Y"] = 350;

            Console.WriteLine(c1.X + " : " + c1.Y);
        }

        // Коллекции
        public static void Collections()
        {
            // Программирование от интерфейсов
            // Принцип, когда переменные или агрументы указываются на основе интерфейса, а не класса
            IList<String> names = new List<String>();
            names.Add("First");
            names.Add("Second");
            names.Add("Third");

            foreach (String item in names) Console.WriteLine(item);
        }

        // Переменная типа делегат содержит ссылку на метод, который ничего не возвращает и не имеет входные параметры
        public delegate void Electricity(object sender, EventArgs args); 
        
        class Switcher
        {
            // Модификатор event запрещает вызвать метод измне, а только как метод данного класса
            public event Electricity ElectricityOn;

            // Best practice - защищенный виртуальный метод
            protected virtual void OnElectricity()
            {
                ElectricityOn?.Invoke(this, new EventArgs());
            }

            public void switchOn()
            {
                Console.WriteLine("Выключатель включен!");
                // if(ElectricityOn != null) ElectricityOn();
                // ElectricityOn.Invoke();
                // ElectricityOn?.Invoke(this, new EventArgs()); // Если не null, вызываем метод Invoke

                OnElectricity();
            }
        }

        class Lamp
        {
            public void LightOn(object sender, EventArgs args)
            {
                Console.WriteLine("Лампа зажглась!");
            }
        }

        class TVSet
        {
            public void TvOn(object sender, EventArgs args)
            {
                Console.WriteLine("Телевизор включен!");
            }
        }

        // Делегат
        public static void Delegates()
        {
            Switcher sw = new Switcher();
            Lamp lamp = new Lamp();
            TVSet tv = new TVSet();

            // Подписка на событие
            sw.ElectricityOn += lamp.LightOn;
            sw.ElectricityOn += tv.TvOn;

            sw.switchOn();
        }

        // Абстрактный класс
        public abstract class Person
        {
            public string Name;
            public int Age;

            public Person(string Name = "Незнакомец", int Age = 18)
            {
                this.Name = Name;
                this.Age = Age;
            }
        }

        // Потомок (partial - описание класса размазано по разным модулям)
        public partial class Employee : Person, IDisposable
        {
            public string Position;

            private bool isDisposed;

            public Employee(string Name, int Age, string Position) : base(Name, Age) // Вызываем конструктор базового класса
            {
                // Чтобы вызвать реализацию родителя можно обратиться base.Name, в случае если мы переобпределили в наследнике метод/параметр
                this.Position = Position;
                Show();

                Console.WriteLine("Создано соединение...");
                this.isDisposed = false;

                // Отмена вызова деструктора
                GC.SuppressFinalize(this);
            }

            // Деструктор
            // Объект в dotNet уничтожается сборщиком мусора на основе остутствия ссылок на объект в контексте работы программы
            ~Employee()
            {
                Dispose();
            }

            // Лучший вариант использования деструктора, это унаследоваться от IDisposable и реализовать метод Dispose
            public void Dispose()
            {
                if (!isDisposed) {
                    Console.WriteLine("Освобождение соединения...");
                    this.isDisposed = !this.isDisposed;
                }
            }

            private void Show()
            {
                Console.WriteLine(this.Position + " " + this.Name + " " + this.Age);
            }
        }

        // Классы и объекты
        public static void ClassesConstructorDestructor()
        {
            /*
            Employee p = new Employee("Сергей", 43, "Преподаватель");

            try
            {
                // Работа с disposable обхектом
            }
            finally
            {
                // Гарантированное освобождение из finally, даже если будет catch exception
                p.Dispose();
            }
            */

            // При использовании using, на выходе будет вызов Dispose автоматически
            /*
            using(Employee p = new Employee("Сергей", 43, "Преподаватель"))
            {

            }
            */

            Employee p = new Employee("Сергей", 43, "Преподаватель");
            p.ShowName(); // partial метод из модуля Employee.cs
        }

        public static void StaticClasses()
        {
            string s = "hello sergey!";
            string s1 = s.Capitalize();
            Console.WriteLine(s + " = " + s1);
        }

        // IEnumerable. Смысл интерфейса - нечто абстрактное, что позволяет перебирать данные
        public static void Enumeration()
        {
            IEnumerable<int> GetInts()
            {
                return new List<int>() { 100, 200, 300 };
            }

            IEnumerable<int> GetInts2()
            {
                for (int i = 1; i <= 3; i++) yield return i*101;
            }

            var list1 = GetInts();
            var list2 = GetInts2();

            Console.WriteLine("List1:\n");
            foreach (var i in GetInts()) Console.WriteLine(i);
            Console.WriteLine("\nList2:\n");
            foreach (var j in list2) Console.WriteLine(j);

            var list3 = Program.GetInts3();
            Console.WriteLine("\nList3:\n");
            foreach (var k in list3) Console.WriteLine(k);
        }

        private class User
        {
            public int Id;
            public string Name;
            public string Login;
        }

        // Работа с файлами. Сериализиция. Десериализация
        public static void FileSystem()
        {
            // Каталог с исполняемым файлом текущего приложения
            Console.WriteLine(System.IO.Directory.GetCurrentDirectory());

            User user = new User();
            user.Id = 1;
            user.Name = "Alexandr";
            user.Login = "gpbu13053";

            var strUser = JsonConvert.SerializeObject(user);

            Console.WriteLine("Сериализованный класс: " + strUser);
        }
    }
}
