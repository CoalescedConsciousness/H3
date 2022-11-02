using System;
using System.Collections.Generic;

using System.Linq;  // Husk

namespace CsharpExercises
{
    class BasicLINQDemo
    {
        static void Main()
        {
            int[] numberArr = { 9, 3, 4, 1, 8, 6, 2, 5, 7 };

            Console.WriteLine("--- OrderByDescending -----");
            foreach (var item in numberArr.OrderByDescending(n => n))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("--- OrderByDescending + Take(5) -----");
            foreach (var item in numberArr.OrderByDescending(n => n).Take(5))
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("--- OrderByDescending + Take(5) + Sum + moms -----");
            Console.WriteLine(numberArr.OrderByDescending(n => n).Take(5).Sum(n => n * 1.25));
        }
    }
}
