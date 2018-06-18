using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//LINQ. Lambda Expressions
namespace Lecture14_Practice
{
    //Функция - однозначное определение множества из области определения в область значения
    //=> - Лямбда оператор
    delegate double MyDelegate(double x);
    //Лямбда выражение имеет след синтаксис: слева от лямбда оператора определяется список параметров,
    //а справа блок выражений, использующий эти параметры
    //(список_параметров => выражение.



    class Program
    {
        //объявляем делегат получающий две целочисленные переменные
        public delegate int MathDelegate(int x, int y);


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
            md1 = n =>
            {
                double s = 0;
                for (int i = 2; i <= n; i++) s += 1.0 / 1;
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







            Console.ReadKey();

        }
    }
}
