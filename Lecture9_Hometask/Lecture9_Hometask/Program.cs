using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lecture9_Hometask
{
    class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public string Lastname { get; set; }

        public Student(string name, string lastname)
        {
            this.Name = name;
            this.Lastname = lastname;
        }

        public int CompareTo(Student other)
        {
            int comp = Lastname.CompareTo(other.Lastname);
            if (comp == 0)
            {
                return Name.CompareTo(other.Name);
            }
            return comp;
        }
    }

    class RangeException : Exception
    {
        public int x { get; }

        public override string Message => "Оценка вышла за диапазон";

        public RangeException(int x)
        {
            this.x = x;
        }

    }

    class ExistException : Exception
    {

        
    }

    class DictionaryStudents
    {
        SortedDictionary<Student, int> dict = new SortedDictionary<Student, int>();

        public void AddStudent(Student st, int mark)
        {
            try
            {
                if ((mark < 0) | (mark > 100))
                {
                    throw new RangeException(mark);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Недопустимое значение", e.Message);
            }

            dict.Add(st, mark);
        }

        public void AddStudents(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter student's name: ");
                string stname = Console.ReadLine();
                Console.WriteLine("Enter student's lastname: ");
                string stlastname = Console.ReadLine();
                Console.WriteLine("Enter student's mark: ");
                int stmark = Int32.Parse(Console.ReadLine());

                AddStudent(new Student(stname, stlastname), stmark);
            }
        }

        public void ListStudents()
        {
            foreach (KeyValuePair<Student, int> entry in dict)
            {
                Console.WriteLine("{0} {1} has mark {2}", entry.Key.Name, entry.Key.Lastname, entry.Value);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            DictionaryStudents ds = new DictionaryStudents();
            ds.AddStudents(3);
            ds.ListStudents();


            Console.ReadKey();

        }
    }
}
