using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET_LINQ_ConsoleApp_
{

    class Program
    {
        #region 10
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string City { get; set; }

            public override string ToString()
            {
                return $"Name - {Name} | Age - {Age} | City - {City}";
            }

        }
        #endregion


        #region 11
        class Employee
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public int DepId { get; set; }

            public override string ToString()
            {
                return $"Id - {Id} | FirstName - {FirstName} | LastName - {LastName} | Age - {Age} | DepId - {DepId}";
            }
        }

        class Department
        {
            public int Id { get; set; }
            public string Country { get; set; }
            public string City { get; set; }

            public override string ToString()
            {
                return $"Id - {Id} | Country - {Country} | City - {City}";
            }
        }
        #endregion




        static void Main(string[] args)
        {

            #region ListFor10
            List<Person> person = new List<Person>() {
                new Person(){ Name = "Andrey", Age = 24, City = "Kyiv" },
                new Person(){ Name = "Liza", Age = 18, City = "Moscow" },
                new Person(){ Name = "Oleg", Age = 15, City = "London" },
                new Person(){ Name = "Sergey", Age = 55, City = "Kyiv" },
                new Person(){ Name = "Sergey", Age = 32, City = "Kyiv" }
            };
            #endregion


            #region ListFor11
            List<Department> departments = new List<Department>()
            {
                new Department(){ Id = 1, Country = "Ukraine", City = "Donetsk" },
                new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
                new Department(){ Id = 3, Country = "France", City = "Paris" },
                new Department(){ Id = 4, Country = "Russia", City = "Moscow" }
            };

            List<Employee> employees = new List<Employee>()
            {
                new Employee() { Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
                new Employee() { Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
                new Employee() { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 },
                new Employee() { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
                new Employee() { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
                new Employee() { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 },
                new Employee() { Id = 7, FirstName = "Nikita", LastName = " Krotov ", Age = 27,DepId = 4 }
            };
            #endregion



            #region List12
            List<Department> departments2 = new List<Department>()
            {
                new Department(){ Id = 1, Country = "Ukraine", City = "Donetsk" },
                new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
                new Department(){ Id = 3, Country = "France", City = "Paris" },
                new Department(){ Id = 4, Country = "Russia", City = "Moscow" }
            };
            List<Employee> employees2 = new List<Employee>()
            {
                new Employee() { Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
                new Employee() { Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
                new Employee() { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 },
                new Employee() { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
                new Employee() { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
                new Employee() { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 },
                new Employee() { Id = 7, FirstName = "Nikita", LastName = "Krotov", Age = 27, DepId = 4 }
            };
            #endregion




            #region LINQFor10
            //10.1) Выбрать людей, старших 25 лет.
            Console.WriteLine("10_1");
            var result10_1 = person.Where(p => p.Age > 25);
            foreach (var item in result10_1)
            {
                Console.WriteLine(item);
            }


            //10.2) Выбрать людей, проживающих не в Киеве.
            Console.WriteLine();
            Console.WriteLine("10_2");
            var result10_2 = person.Where(p => p.City == "Kyiv");
            foreach (var item in result10_2)
            {
                Console.WriteLine(item);
            }

            //10.3) Выбрать имена людей, проживающих в Киеве.
            Console.WriteLine();
            Console.WriteLine("10_3");
            var result10_3 = person.Where(p => p.City == "Kyiv").Select(i => i.Name);
            foreach (var item in result10_3)
            {
                Console.WriteLine(item);
            }

            //10.4) Выбрать людей старших 35 лет с именем Sergey.
            Console.WriteLine();
            Console.WriteLine("10_4");
            var result10_4 = person.Where(p => p.Age > 35 && p.Name == "Sergey");
            foreach (var item in result10_4)
            {
                Console.WriteLine(item);
            }

            //10.5) Выбрать людей, проживающих в Москве.
            Console.WriteLine();
            Console.WriteLine("10_5");
            var result10_5 = person.Where(p => p.City == "Moscow");
            foreach (var item in result10_5)
            {
                Console.WriteLine(item);
            }
            #endregion


            #region LINQFor11
            // 11.1) Выбрать имена и фамилии сотрудников, работающих в Украине, но не в Донецке.
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("11_1");
            var result11_1 = from emp in employees
                             from dep in departments where(emp.DepId == dep.Id & dep.Country == "Ukraine") select new { FirstName = emp.FirstName, LastName = emp.LastName };

            foreach (var item in result11_1)
            {
                Console.WriteLine(item);
            }


            // 11.2) Вывести список стран без повторений.
            Console.WriteLine();
            Console.WriteLine("11_2");
            var result11_2 = departments.Select(p => new { Country = p.Country }).Distinct();
            foreach (var item in result11_2)
            {
                Console.WriteLine(item);
            }


            // 11.3) Выбрать 3 - x первых сотрудников, возраст которых превышает 25 лет.
            Console.WriteLine();
            Console.WriteLine("11_3");
            var result11_3 = employees.Where(e => e.Age > 25).Take(3);
            foreach (var item in result11_3)
            {
                Console.WriteLine(item);
            }


            // 11.4) Выбрать имена, фамилии и возраст студентов из Киева, возраст которых превышает 23 года
            Console.WriteLine();
            Console.WriteLine("11_4");
            var result11_4 = from emp in employees
                             from dep in departments
                             where dep.Id == emp.DepId
                             where emp.Age < 23
                             select new { FName = emp.FirstName, LName = emp.LastName, Age = emp.Age };
            foreach (var item in result11_4)
            {
                Console.WriteLine(item);
            }
            #endregion



            #region LINQFor12
            //12.1) Упорядочить имена и фамилии сотрудников по алфавиту,которые проживают в Украине. Выполнить запрос немедленно.
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("12_1");
            var result12_1 = (from emp in employees2
                             from dep in departments2
                             where emp.DepId == dep.Id
                             where dep.Country == "Ukraine"
                             orderby emp.LastName ascending
                             orderby emp.FirstName ascending
                             select new { FirstName = emp.FirstName, LastName = emp.LastName }).ToList();
            foreach (var item in result12_1)
            {
                Console.WriteLine(item);
            }
            #endregion


            //12.2) Отсортировать сотрудников по возрастам, по убыванию. Вывести Id, FirstName, LastName, Age. Выполнить запрос немедленно.
            Console.WriteLine();
            Console.WriteLine("12_2");
            var result12_2 = employees2.Select(e => new { Id = e.Id, FirstName = e.FirstName, LastName = e.LastName, Age = e.Age }).OrderBy(e => e.Age).ToList();
            foreach (var item in result12_2)
            {
                Console.WriteLine(item);
            }


            // 3) Сгруппировать студентов по возрасту. Вывести возраст и сколько раз он встречается в списке.
            Console.WriteLine();
            Console.WriteLine("12_3");
            var result12_3 = employees2.GroupBy(e => e.Age).Select(g => new { Age = g.Key, Count = g.Count()});

            foreach (var item in result12_3)
            {
                Console.WriteLine(item);
            }



            Console.ReadLine();
        }
    }
}
