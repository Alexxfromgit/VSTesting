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
            try
            {
                //Create an instance of StreamReader to read the file
                //the using statement also closes the StreamReader
                using (StreamReader sr = new StreamReader("Testfile.txt"))
                {
                    string line;
                    //Read and display lines from the file until the end of the file is reached
                    while ((line = sr.ReadLine())!=null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                //Let the user know what was wrong
                Console.WriteLine("The file could not be read: ");
                Console.WriteLine(e.Message);
            }

            //------------------------------------------------------
            string currentFolder = Directory.GetCurrentDirectory();
            Console.WriteLine("Текущая папка {0}", currentFolder);

            var dirName = Directory.GetDirectories(@"d:\");
            Console.WriteLine("Список директорий диска D:");
            foreach (var item in dirName)            
                Console.WriteLine(item);            

            var fileName = Directory.GetFiles(@"d:\");
            Console.WriteLine("Список файлов диска D:");
            foreach (var item in fileName)            
                Console.WriteLine(item);
            





            Console.ReadKey();


        }
    }
}
