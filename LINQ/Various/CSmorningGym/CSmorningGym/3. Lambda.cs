// 1. Find udviklere, hvis navn starter med K. Der er 3 måder at gøre det på:
// 2. Explicit Method... bliver hurtigt besværlig
// 3. Med Delegates
// 4. Med Lambda

using System;
using System.Collections.Generic;
using System.Linq;

namespace CSmorningGym
{
    public class Lambda
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee { Id = 1, Name = "Katja" },
                new Employee { Id = 2, Name = "Christian" },
                new Employee { Id = 3, Name = "Anders" }
            };

            // With explicit method
            foreach (var employee in developers.Where(NameStartsWithK))
            {
                Console.WriteLine(employee.Name);
            }

            // With Delegate
            foreach (var employee in developers.Where(delegate (Employee employee)
                {
                    return employee.Name.StartsWith("K");
                }))
            {
                Console.WriteLine(employee.Name);
            }

            // With Lambda
            foreach (var employee in developers.Where(e => e.Name.StartsWith("K")))
            {
                Console.WriteLine(employee.Name);
            }
        }

        private static bool NameStartsWithK(Employee employee)
        {
            return employee.Name.StartsWith("K");
        }
    }

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}