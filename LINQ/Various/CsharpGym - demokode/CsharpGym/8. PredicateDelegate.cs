// Den indbyggede generiske:
// delegate bool Predicate<T>(T obj)
// benyttes. Returnerer bool typen.

using System;

namespace CsharpExercises
{
    class PredicateDelegate
    {
        static void Main()
        {
            DisplayNumbers(Filter);
        }

        private static Boolean Filter(int tal)
        {
            return tal % 2 == 0;
        }

        static void DisplayNumbers(Predicate<int> match)
        {
            int[] numberArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Console.WriteLine("Følgende tal opfylder betingelsen:");
            foreach (int item in numberArr)
            {
                if (match(item))
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
