using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lecture10_Practice
{
    //Нетипизированный интерфейс IEnumerable
    class Num : IEnumerable //простейший итератор
    {
        int x, y, z; //по умолчанию private
        public Num(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public IEnumerator GetEnumerator()
        {
            //управление циклом foreach
            yield return z; //возвращает одно значение на одной итерации
            yield return y;
            yield return x;
        }
    }

    class Demo : IEnumerable
    {
        private int[] mas;
        public Demo()
        {
            mas = new int[] { 5, 4, 1, 2, 3 };
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < 5; i++)
            {
                if (mas[i] %2 != 0 && mas[i] != 0)
                {
                    yield return mas[i];
                }
            }                            
        }
    }

    class TempRecord
    {
        //Массив значений температур
        private int[] temps = new int[] { 12, 16, 15, 16, 18 };

        //Свойство возвращающее кол-во эл-ов массива
        //(только для чтения)
        public int Length
        {
            get { return temps.Length; }
        }

        //Индексатор для доступа к массиву
        public int this[int index]
        {
            get => temps[index];
            set => temps[index] = value;
        }
    }

    class DemoStringIndex
    {
        private int x;
        private int y;

        public DemoStringIndex(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        //Индексатор возвращает целое число, а получает строку
        public int this[string index]
        {
            get
            {
                if (index == "first")                
                    return x;                
                else                
                    if (index == "second")                    
                        return y;                    
                    else                    
                        throw new IndexOutOfRangeException();                
            }
        }
    }

    class DemoArray
    {
        int[,] myArray; //закрытый массив
        int n, m; //закрытые поля, размерность массива

        public DemoArray(int sizeN, int sizeM) //конструктор для получения длинны массива
        {
            myArray = new int[sizeN, sizeM];
            this.n = sizeN;
            this.m = sizeM;
        }
        
        //можно и так
        public int LengthN => n;

        //можно и так тоже
        public int LengthM
        {
            get { return m; }
        }

        public int this[int i, int j] //индексатор
        {
            get
            {
                if (i < 0 || i >= n || j < 0 || j >= m)
                {
                    throw new Exception("Выход за границы массива");
                }
                else
                {
                    return myArray[i, j];
                }
            }
            set
            {
                if (i < 0 || i >= n || j < 0 || j >= m)
                {
                    throw new Exception("Выход за границы массива");
                }
                else
                {
                    if (value >= 0 && value <= 100)
                    {
                        myArray[i, j] = value;
                    }
                    else
                    {
                        throw new Exception("Присваивается недопустимое значение");
                    }
                }
            }
        }
    }

    public class Mammal { }
    public class Dog : Mammal
    {
        public override string ToString()
        {
            return "Im a dog";
        }
    }
    public class Cat : Mammal
    {
        public override string ToString()
        {
            return "Im a cat";
        }
    }
    public class Elephant : Mammal { }
    public class Fish { }
    public class Reptilis { }

    public class Patients : CollectionBase
    {
        public void AdmitPatient(object patient)
        {
            if ((patient) is Elephant)
            {
                Console.WriteLine("This is no one will write" + "No no no");
            }
            else
            {
                if ((patient) is Mammal | (patient) is Fish | (patient) is Reptilis)
                {
                    this.List.Add(patient);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Коллекция нетипизированная ОЧЕРЕДЬ
            Queue q1 = new Queue();
            q1.Enqueue("1");
            q1.Enqueue('2');
            q1.Enqueue("Three");
            q1.Enqueue(5);
            Console.WriteLine("First element: " + q1.Peek());
            Console.WriteLine("All elements: " + q1.Count);

            while (q1.Count > 0)
            {
                Console.WriteLine(q1.Dequeue());
            }
            /*
            foreach (var item in q1)            
                Console.WriteLine(item);            
            */

            //Коллекция СТЕК
            Stack s1 = new Stack();
            s1.Push(6);
            s1.Push("2");
            s1.Push('1');
            s1.Push(3);
            Console.WriteLine("Upper element: " + s1.Peek());
            Console.WriteLine("All elements: " + s1.Count);
            //Извлечение элементов
            while (s1.Count > 0)
            {
                Console.WriteLine(" " + s1.Pop());
            }
            /*
            //С первого элемента!
            foreach (var item in s1)            
                Console.WriteLine(s1.Pop());
            */

            Num n = new Num(2, 5, 9);
            foreach (var item in n)            
                Console.WriteLine(item);

            Demo d = new Demo();
            foreach (int item in d)            
                Console.WriteLine(item);

            TempRecord tr = new TempRecord();
            //Установка значений через индексатор
            //через set устанавливаются значения
            tr[3] = 15;
            tr[4] = 17;

            //Получение значений через индексатор
            for (int i = 0; i < tr.Length; i++)
            {
                Console.WriteLine("Element #{0} equals {1}", i, tr[i]);
            }

            //пример индексатора где индексатор принимает строку
            DemoStringIndex dm = new DemoStringIndex(5, 6);
            Console.WriteLine("{0}    {1}", dm["first"], dm["second"]);

            DemoArray a = new DemoArray(3, 3);

            for (int i = 0; i < a.LengthN; i++, Console.WriteLine())
            {
                for (int j = 0; j < a.LengthM; j++)
                {
                    a[i, j] = i * j; //использование индексаторов
                    Console.WriteLine("{0,5}", a[i, j]);
                }
            }
            Console.WriteLine();
            try
            {
                //Раскомментировать по очереди чтобы посмотреть на разные ошибки
                //Console.WriteLine(a[3, 3]);
                //a[0, 0] = 200;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Cat fluffy = new Cat();
            Elephant slon = new Elephant();
            Dog goldy = new Dog();
            Patients SickPets = new Patients();
            SickPets.AdmitPatient(fluffy);
            SickPets.AdmitPatient(slon);
            SickPets.AdmitPatient(goldy);
            foreach (object pet in SickPets)
            {
                Console.WriteLine(pet);
            }




            Console.ReadKey();

        }
    }
}
