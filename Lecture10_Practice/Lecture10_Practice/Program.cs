using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lecture10_Practice
{



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




        }
    }
}
