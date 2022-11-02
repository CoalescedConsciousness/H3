using System;
// 1. En Count metode oprettes, først uden this
// 2. this tilføjes for at gøre metoden til en Extension Method. Bemærk den mere logiske måde metoden kaldes på.
// 3. Tilføj namespace System.Linq og se alle de andre LINQ Extension Methods.

using System.Collections.Generic;
// using System.Linq;

namespace CSmorningGym
{
    public class ExtensionMethod
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee { Id = 1, Name = "Katja" },
                new Employee { Id = 2, Name = "Christian" },
                new Employee { Id = 3, Name = "Anders" }
            };

            // With normal method
            Console.WriteLine(MyLinq.Count(developers));

            // With Extension method
            Console.WriteLine(developers.Count());
        }
    }

    public static class MyLinq
    {
        public static int Count<T>(this IEnumerable<T> sequence)
        {
            int count = 0;
            foreach (var item in sequence)
            {
                count++;
            }
            return count;
        }
    }

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
