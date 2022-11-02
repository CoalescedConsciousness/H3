// Lambda Expression er blot en anden måde at lave en Anonymous Method på,
// men meget simplere at skrive!

using System;

namespace CsharpExercises
{
    class LambdaFilter
    {
        static void Main()
        {
            // Som Lambda Statement (flere linier i en blok og return)
            DisplayNumbers(tal =>
                {
                    return tal % 2 == 0;
                });

            // Som Lambda Expression (kun én linie og ingen return)
            DisplayNumbers(tal => tal % 2 == 0);
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
