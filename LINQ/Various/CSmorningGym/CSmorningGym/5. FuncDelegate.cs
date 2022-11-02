// 1. Demo af Func<T, TResult> delegate-typen og hvordan den eksekveres med Square(4)
// 2. Demo af en Func-delegate-variabel brugt som parameter til Foo metoden. 
//      Giver mulighed for at ændre gange til addition uden at ændre i Foo metoden.
// 3. En Lamba metode med Method Body og return.

using System;

namespace CSmorningGym
{
    public class FuncDelegate
    {
        static void Main(string[] args)
        {
            Func<int, int> Square = x => x * x;
            Console.WriteLine(Square(4));
            //Console.WriteLine(Foo(Square));

            // With method body
            //Func<int, int, int> Add = (x, y) =>
            //{
            //    int temp = x + y;
            //    return temp;
            //};
            //Console.WriteLine(Add(3, 4));

        }

        static int Foo(Func<int, int> calc)
        {
            Console.WriteLine("Indtast et tal");
            int tal = Convert.ToInt32(Console.ReadLine());
            return calc(tal);
        }
    }
}