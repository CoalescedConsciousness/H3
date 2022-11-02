// Bemærk at vi også kunne have udvidet int[] i stedet for IEnumerable<int>
// Mere logisk at kalde SumNumbers() vha. Extension metodekald:
//  numberArr.SumNumbers()

using System;
using System.Collections.Generic;

namespace CsharpExercises
{
    class ExtensionMethodDemo
    {
        static void Main()
        {
            int[] numberArr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Console.WriteLine("Total sum er: " + ExtensionMethodClass.SumNumbers(numberArr));   // Normal metodekald
            Console.WriteLine("Total sum er: " + numberArr.SumNumbers());                       // Extension metodekald
        }   
    }

    static class ExtensionMethodClass
    {
        public static int SumNumbers(this IEnumerable<int> numArr)
        {
            int result = 0;
            foreach (int item in numArr)
            {
                result += item;
            }
            return result;
        }
    }
}
