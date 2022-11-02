// Metoden DisplayNumbers() udskriver alle lige tal
// Filteret, der bestemmer betingelsen, er hardkodet
// i metoden og kan ikke ændres fra Main()

using System;

namespace CsharpExercises
{
    class HardcodedFilter
    {
        static void Main()
        {
            DisplayNumbers();
        }

        static void DisplayNumbers()
        {
            int[] numberArr = {1, 2, 3, 4, 5, 6, 7, 8, 9};

            foreach (int item in numberArr)
            {
                if (item % 2 == 0)
                {
                    Console.WriteLine("2 går op i {0}", item);
                }
            }
        }
    }
}
