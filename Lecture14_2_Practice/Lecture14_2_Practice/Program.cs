using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//LINQ
namespace Lecture14_2_Practice
{
    public class Employee
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Decimal Salary { get; set; }
        public string Nationality { get; set; }
    }



    class Program
    {
        static void Main(string[] args)
        {
            //---------------------------------------------
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var x = numbers
                .Where(n => n > 0)
                .Where(n => n % 2 == 0)
                .Count(n => n < 10);

            Console.WriteLine(x);
            //----------------------------------------------
            //var - само определяет какой тип будет возвращен
            var t = from z in numbers select z;

            foreach (var a in t)
                Console.WriteLine("{0}  ", a);
            //----------------------------------------------
            int[] numbers2 = { 1, 2, 3, 4 };

            var query = from c in numbers2
                        where c % 2 == 0
                        select c * 2;

            foreach (var item in query)
            {
                Console.WriteLine("{0}  ", item);
            }
            Console.WriteLine();
            //----------------------------------------------

            var employees = new List<Employee>()
            {
                new Employee {FirstName = "Petr", LastName = "Petrov" },
                new Employee {FirstName = "Semen", LastName = "Semenov" },
                new Employee {FirstName = "Ivan", LastName = "Ivanov" },
                new Employee {FirstName = "Andrey", LastName = "Semenov" }
            };

            var query1 = from emp in employees
                         let fullName = emp.LastName + " " + emp.FirstName //let - служеб слово которое объявляет переменную (fullName) автоматич становится типом стринг изза того что присваивается стринг
                         orderby fullName
                         select fullName;
            //получаем массив строк отсортированных по алфавиту
            foreach (var item in query1)
            {
                Console.WriteLine(item);
            }
            //------------------------------------------------
            var employees2 = new List<Employee>()
            {
                new Employee {FirstName = "Petr", LastName = "Petrov", Salary = 450 },
                new Employee {FirstName = "Semen", LastName = "Semenov", Salary = 950 },
                new Employee {FirstName = "Ivan", LastName = "Ivanov", Salary = 850 },
                new Employee {FirstName = "Andrey", LastName = "Semenov", Salary = 1100 }
            };

            var query3 = from employee in employees2
                         where employee.Salary > 800
                         orderby employee.LastName, employee.FirstName
                         select employee;

            Console.WriteLine("\nСамые высокооплачиваемые");
            foreach (var item in query3)
            {
                Console.WriteLine("{0} {1} получает ${2}", item.LastName, item.FirstName, item.Salary);
            }

            /*
            var query4 = employees
                .Where(emp => emp.Salary > 800)
                .OrderBy(emp => emp.LastName)
                .OrderBy(emp => emp.FirstName)
                .Select(emp => new
                {
                    LastName = emp.LastName,
                    FirstName = emp.FirstName,
                    Salary = emp.Salary
                });
            */

            //-----------------------------------------------
            //смешанный синтаксис запроса
            //отсортировать по фамилии и вывести имя первого в списке
            string name = (from employee in employees2 //можно использовать var как универсальное средство объявления переменных
                           orderby employee.LastName
                           select employee).First().FirstName;

            Console.WriteLine("\nИмя первого в списке {0}", name);

            //Вывести сотрудников в котором есть буква е в имени
            int nu = (from employee in employees2
                      where employee.FirstName.Contains("e")
                      select employee).Count();

            Console.WriteLine("\nКолличество имен с буквой е = {0}", nu);
            //-----------------------------------------------
            var employees3 = new List<Employee>()
            {
                new Employee {FirstName = "Petr", LastName = "Petrov", Nationality = "Ukraine"},
                new Employee {FirstName = "Semen", LastName = "Semenov", Nationality = "Russian"},
                new Employee {FirstName = "Ivan", LastName = "Ivanov", Nationality = "Ukraine"},
                new Employee {FirstName = "Andrey", LastName = "Semenov", Nationality = "American"}
            };

            var query5 = from emp in employees3
                         orderby emp.Nationality,
                                 emp.LastName descending,
                                 emp.FirstName descending
                         select emp;

            foreach (var item in employees3)
            {
                Console.WriteLine("{0} {1} {2}", item.LastName, item.FirstName, item.Nationality);
            }
            //------------------------------------------------------
            //Группировка

            var employees4 = new List<Employee>()
            {
                new Employee {FirstName = "Petr", LastName = "Petrov", Nationality = "Ukraine"},
                new Employee {FirstName = "Semen", LastName = "Semenov", Nationality = "Russian"},
                new Employee {FirstName = "Ivan", LastName = "Ivanov", Nationality = "Ukraine"},
                new Employee {FirstName = "Andrey", LastName = "Semenov", Nationality = "American"}
            };

            var query6 = from emp in employees4
                         group emp by new
                         {
                             Nationality = emp.Nationality,
                             LastName = emp.LastName
                         };

            foreach (var group in query6)
            {
                Console.WriteLine(group.Key);
                foreach (var employee in group)
                {
                    Console.WriteLine(employee.FirstName);
                }
                Console.WriteLine();
            }




            Console.ReadKey();
        }
    }
}
