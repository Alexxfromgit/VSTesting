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








            Console.ReadKey();

        }
    }
}
