using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lecture9_Practice
{
    class DivisionException : Exception
    {
        public int x { get; }
        public int y { get; }
        public override string Message
        {   //Переопределение свойства Message
            get
            {
                return "Некорректная операция";
            }
        }
        public DivisionException(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //Нетипизированная коллекция - для хранения любых объектов
            ArrayList a = new ArrayList();
            a.Add("Computer");
            a.Add("Programmer");
            a.Add("C# cool");
            a.Add(true);
            a.Add(new DateTime(2015, 3, 20));
            a.Add(new Object());
            a.Add(new { Name = "Alex", LastNAme = "Rub" });

            foreach (object obj in a) //тип универсальный обджект            
                Console.WriteLine(obj);            

            for (int i = 0; i < a.Count; i++)            
                Console.WriteLine(a[i]);

            //Типизированная коллекция
            List<string> names = new List<string>();
            names.Add("Jon Gates");
            names.Add("Alex Rub");
            names.Add("Sergey Bring");

            foreach (string str in names)
                Console.WriteLine(str);

            //Ассоциативный массив
            Hashtable currencies = new Hashtable();
            currencies.Add("US", "Dollar");
            currencies.Add("Japan", "Yen");
            currencies.Add("Australia", "Dollar");
            Console.WriteLine("US Currency", currencies["US"]);

            //Dictionary
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("Pascal", 1968);
            dict.Add("C", 1972);
            dict.Add("C++", 1985);
            dict.Add("Java", 1995);
            dict.Add("C#", 2000);

            if (dict.ContainsKey("Java"))
            {
                dict.Remove("Java");
            }

            foreach (KeyValuePair<string, int> entry in dict) //foreach (var entry in dict)
            {
                string k = entry.Key;
                int v = entry.Value;
                Console.WriteLine("{0} was created in {1} year", k, v);
            }

            //Ассоциативный массив. без вмешательства человека каждую записаь вставляет упорядоченную по ключу значению.
            SortedList colors = new SortedList();
            colors.Add('w', "white");
            colors.Add('r', "red");
            colors.Add('g', "green");
            colors.Add('b', "black");
            //Ключи должны быть сравниваемы. Должны сортироваться

            foreach (DictionaryEntry de in colors)            
                Console.WriteLine("Key: {0} and Value: {1}", de.Key, de.Value);

            //Типизированый SortedList
            SortedList<Car, string> s1 = new SortedList<Car, string>();
            s1.Add(new Car("Ford", 2000), "USA");
            s1.Add(new Car("Mercedes", 2005), "Germany");

            //Автоматически поддерживает сортировку
            SortedDictionary<string, Department> deptSD = new SortedDictionary<string, Department>();
            deptSD.Add("MKT", new Department("MKT", "Marketing"));
            deptSD.Add("SAL", new Department("SAL", "Sales"));




            Console.ReadKey();
        }
    }
}
