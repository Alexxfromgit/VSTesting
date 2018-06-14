using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace Lecture13_Practice
{
    //Файлы и работа с файлами
    //\n - переход на новую строку
    //\t - табуляция, отступ несколько пробелов

    class Program
    {
        static void Main(string[] args)
        {
            /*
            String s1; //объект класса стринг
            string s2; //переменная типа стринг

            s1 = "\nОбычная\n\t\t\tконстанта";
            s2 = @"\nНеобычная\n\tконстанта";
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine();
            */

            //using - в юзинг объявляем объект который будет сущ только в рамках этого блока
            //автоматически создается в папке дебаг если путь не указан явно
            using (StreamWriter sw = new StreamWriter("Testfile.txt"))
            {
                //Add some text to the file
                sw.WriteLine("Testing text1");
                sw.WriteLine("Testing text2");

                //Arbitrary objects can also be written to the file
                sw.Write("The date is: ");
                sw.WriteLine(DateTime.Now);
            }







            Console.ReadKey();


        }
    }
}
