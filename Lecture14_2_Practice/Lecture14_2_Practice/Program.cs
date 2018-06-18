using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//LINQ
namespace Lecture14_2_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var x = numbers
                .Where(n => n > 0)
                .Where(n => n % 2 == 0)
                .Count(n => n < 10);

            Console.WriteLine(x);




            Console.ReadKey();
        }
    }
}
