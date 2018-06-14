using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; //подключение бинарной сериализации

namespace Lecture13_Practice
{
    //Файлы и работа с файлами
    //\n - переход на новую строку
    //\t - табуляция, отступ несколько пробелов

    //сериализация
    [Serializable]
    class Demo
    {
        int n;
        double d;
        DateTime dt;
        public Demo(int n, double d, DateTime dt)
        {
            this.n = n;
            this.d = d;
            this.dt = dt;
        }
        public override string ToString()
        {
            string s = String.Format("Поле 1 = {0}, поле 2 = {1}, поле 3 = {2}", n, d, dt.ToShortDateString());
            return s;
        }
    }

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

            //Делает тоже самое что предыдущие два блока
            Console.WriteLine("Список файлов и дерикторий диска D:");
            string[] ff = Directory.GetFileSystemEntries("d:\\");
            foreach (string entry in ff)            
                Console.WriteLine("{0}", entry);

            //Directory - статический класс. Все методы этого класса статические. Не нужно создавать методы
            //методы вызываем у самого класса
            //DirectoryInfo - заставляет сначала создать объект а потом использовать. НЕ статический класс.

            //Создание папки с заданным именем
            string directoryName = "MyDirectory";
            if (!Directory.Exists(@"D:" + directoryName))
            {
                DirectoryInfo d1 = new DirectoryInfo(@"D:\" + directoryName);
                d1.Create();
            }

            if (File.Exists(@"D:\MyDirectory\MyFile.txt"))
                File.Delete(@"D:\MyDirectory\MyFile.txt");

            File.AppendAllText(@"D:\MyDirectory\MyFile.txt", "I like C#. ");
            File.AppendAllText(@"D:\MyDirectory\MyFile.txt", "Let us like it together");
            //Копирует существующий файл в новый файл
            //Перезапись файла с тем же именем разрешена
            File.Copy(@"D:\MyDirectory\MyFile.txt", @"D:\MyDirectory\CopeFile.txt", true);
            string s = File.ReadAllText(@"D:\MyDirectory\CopeFile.txt");
            Console.WriteLine(s);

            //Есть так же FileInfo как и для DirectoryInfo

            //----------------------------------------------------------
            //BACK UP FILES
            //----------------------------------------------------------
            /*
            DirectoryInfo backupFoleder = new DirectoryInfo(@"D:\Democode\backup");
            if (!backupFoleder.Exists)            
                backupFoleder.Create();            
            string currentFolderName = Directory.GetCurrentDirectory();
            DirectoryInfo currentFolder2 = new DirectoryInfo(currentFolderName);
            foreach (FileInfo file in currentFolder2.GetFiles())            
                file.CopyTo(backupFoleder.FullName + @"\" + file.Name);//Ошибка при повторном запуска файл уже существует
            */

            //--------------------------------------------------------------
            //BACK UP CREATED
            //--------------------------------------------------------------

            //--------------------------------------------------------------
            //Информация о сменном носителе
            //--------------------------------------------------------------
            /*
            DriveInfo[] driveOnComputer = DriveInfo.GetDrives();
            foreach (DriveInfo drive in driveOnComputer)
            {
                Console.WriteLine("Drive {0}", drive.Name); //Устройство не готово ошибка(обращается к диску Е!!!
                Console.WriteLine("Files type: {0}", drive.VolumeLabel);
                if (drive.IsReady)
                {
                    Console.WriteLine(" Volume Label: {0}", drive.VolumeLabel);
                    Console.WriteLine(" File System: {0}", drive.DriveFormat);
                    Console.WriteLine(" Total size of drive: {0}", drive.TotalSize);
                    Console.WriteLine(" Total available space: {0}", drive.TotalFreeSpace);
                }
                else
                {
                    Console.WriteLine(" No media available");
                }
                Console.WriteLine();
            }
            */
            //---------------------------------------------------------------

            //Сохранить текущее состояние объекта
            //Сериализация - процесс сохранения объекта в файл на диске
            //4 варианта - двоичная бинарная джейсон сериализация
            //самая универсальная - бинарная. 

            //СЕРИАЛИЗАЦИЯ
            Demo ddd = new Demo(5, 6.5, new DateTime(2018, 01, 29));
            Console.WriteLine("Оригинальный объект");
            Console.WriteLine(ddd);
            //создаем файл
            FileStream fss = new FileStream(@"D:\file.dat", FileMode.Create);
            //создаем объект класса BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            //Сериализируем объект
            formatter.Serialize(fss, ddd);
            //закрываем файл
            fss.Close();

            //ДЕСЕРИАЛИЗАЦИЯ
            //Открываем файл для чтения
            fss = new FileStream(@"D:\file.dat", FileMode.Open);
            //Создаем новый объект класса Demo
            Demo ddd2 = null;
            //Восстанавливаем объект (Десериализируем)
            ddd2 = (Demo)formatter.Deserialize(fss);
            Console.WriteLine("Восстановленный объект");
            Console.WriteLine(ddd2);

            //Сериализация многих объектов с помощью коллекции
            //используем нетипизированную коллекцию
            ArrayList myList = new ArrayList();
            myList.Add("List of objects");
            myList.Add(new Demo(2, 4.5, new DateTime(2018, 06, 12)));
            myList.Add(new Demo(5, 6.7, new DateTime(2018, 06, 14)));
            myList.Add(new DateTime(2018, 12, 25));

            FileStream fs = new FileStream(@"D:\File2.dat", FileMode.Create);
            BinaryFormatter formatter2 = new BinaryFormatter();
            formatter2.Serialize(fs, myList);
            fs.Close();

            fs = new FileStream(@"D:\File2.dat", FileMode.Open);
            ArrayList newList = null;
            newList = (ArrayList)formatter2.Deserialize(fs);
            foreach (object x in newList)            
                Console.WriteLine(x);


            


            Console.ReadKey();


        }
    }
}
