 using System;
// 1. En List<T> gennemløbes med en foreach.
// 2. Demo af Enumerator. Tryk F12 over IEnumerable og se metoden GetEnumerator()

using System.Collections.Generic;

namespace CSmorningGym
{
    public class Enumerator
    {
        static void Main(string[] args)
        {
            IEnumerable<Employee> developers = new Employee[]
            {
                new Employee { Id = 1, Name = "Katja" },
                new Employee { Id = 2, Name = "Christian" },
                new Employee { Id = 3, Name = "Anders" }
            };
            
            foreach (Employee item in developers)
            {
                Console.WriteLine(item.Name);
            }

            #region ENUMERATOR
            Console.WriteLine("\n* Without Syntactic Sugar *");
            IEnumerator<Employee> enumerator = developers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
            }
            #endregion
        }
    }

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
