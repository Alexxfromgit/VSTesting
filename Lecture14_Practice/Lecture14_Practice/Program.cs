using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
//LINQ. Lambda Expressions
namespace Lecture14_Practice
{
    //Функция - однозначное определение множества из области определения в область значения
    //=> - Лямбда оператор
    delegate double MyDelegate(double x);
    //Лямбда выражение имеет след синтаксис: слева от лямбда оператора определяется список параметров,
    //а справа блок выражений, использующий эти параметры
    //(список_параметров => выражение.

    static class MyExtensions
    {
        public static IEnumerable FindItems(this IEnumerable x, Predicate<int> f)
        {
            ArrayList q = new ArrayList();
            foreach (int  y in x)
            {
                if (f(y))
                {
                    q.Add(y);
                }
            }
            return (IEnumerable)q;
        }
    }



    


    class Program
    {
        //объявляем делегат получающий две целочисленные переменные
        public delegate int MathDelegate(int x, int y);

        //-----------------
        static void FindByName(List<string> members, string Name, Func<string, string, bool> predicate)
        {
            foreach (var member in members)
            {
                if (predicate(member, Name))
                {
                    Console.WriteLine(member);
                }
            }
        }


        static void Main(string[] args)
        {
            //f(x) = x + 1
            MyDelegate md1 = x => x + 1;
            Console.WriteLine(md1(2));

            //f(x) = x^2 + 2*x + 4
            md1 = x => x * x + 2 * x + 4;
            Console.WriteLine(md1(2));

            //Вычислить корень квадратный
            md1 = y => Math.Sqrt(y);
            Console.WriteLine(md1(25));

            //s = 1/2 + 1/3 + ... 1/n
            md1 = z =>
            {
                double s = 0;
                for (int i = 2; i <= z; i++) s += 1.0 / 1;
                return s;
            };
            Console.WriteLine(md1(10));

            //Как получить сумму квадратов чисел
            MathDelegate md;
            //Использование анонимного метода. Представление анонимного метода через делегат
            //Передаем делегату блок кода, который и является анонимным методом
            md = delegate (int x, int y) { return (x * x) + (y * y); };
            Console.WriteLine("5*5 + 3*3 = {0}", md(5, 3));

            //Использование лямбда выражения вместо анонимного метода. Представления через лямбда выражение
            md = (x, y) => (x * x) + (y * y);
            Console.WriteLine("5*5 + 3*3 = {0}", md(5, 3));
            //Лямбда выражение представляет собой упрощенную запись анонимных методов

            //-------------------------------------------------------------------------
            //Стандарный делегат Action<>
            //Инкапсулирует метод, который принимает от 1 до 16 параметров
            //и не возвращает значение
            //используется для методов которые ничего не возвращают

            Action<string> PrintString;
            PrintString = s => Console.WriteLine(s);
            PrintString("Hello World!");

            Action<int, int> PrintSumm;
            PrintSumm = (x, y) => Console.WriteLine(x + y);
            PrintSumm(2, 3);

            //---------------------------------------------------------------------------
            //Func<T, TResult> - стандартный делегат
            //Инкапсулирует метод с одним параметром и возвращает значение типа, указанного в параметре TResult.

            Func<int, double> f1 = x => x / 2;
            Func<double, double> f2 = x => x / 2;
            Func<double, int> f3 = x => (int)x / 2;

            int n = 9;
            Console.WriteLine("Result 1 = {0}", f1(n));
            Console.WriteLine("Result 2 = {0}", f2(n));
            Console.WriteLine("Result 3 = {0}", f3(n));

            Func<int, int, bool> f = (x, y) => x == y;
            int a = 5, b = 6, c = 5;
            if (f(a,c))            
                Console.WriteLine("Числа равны");            
            else            
                Console.WriteLine("Числа не равны");

            //----------------------------------------------------------------------------
            //Реалтзация функции определяющая максимум из трех значений
            Func<int, int, int, int> max3 = (k, l, m) => Math.Max(Math.Max(k, l), m);
            Console.WriteLine(max3(2, 8, 5));
            //----------------------------------------------------------------------------

            //------------------------------------------------------------
            var teamMembers = new List<string>
            {
                "Lou Loomis",
                "Smoke Porterhouse",
                "Danny Smith",
                "Ty Webb",
                "Crocodail Danny",
                "Dannyil Jobs"
            };
            Console.WriteLine("\nВсе строки, содержащие Danny");
            FindByName(teamMembers, "Danny", (x, y) => x.Contains(y));
            Console.WriteLine("\nВсе строки, длиннее Danny");
            FindByName(teamMembers, "Danny", (x, y) => x.Length > y.Length);
            Console.WriteLine("\nВсе строки, начинающиеся так же как и Danny");
            FindByName(teamMembers, "Danny", (x, y) => x[0] == y[0]);

            //Расширяющий метод для колл и массив который будет получать в качестве параметра предикат 
            //Прообраз LINQ..
            int[] lst = { 3, -6, 2, -7, 8, 5, 4 };

            Console.WriteLine();
            var data1 = lst.FindItems(x => x % 2 == 0);
            foreach (var t in data1)
                Console.WriteLine(t);

            Console.WriteLine();
            var data2 = lst.FindItems(x => x % 2 != 0);
            foreach (var t in data2)
                Console.WriteLine(t);

            Console.WriteLine();
            var data3 = lst.FindItems(x => x > 0);
            foreach (var t in data3)
                Console.WriteLine(t);

            


            Console.ReadKey();

        }
    }
}
