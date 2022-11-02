// 1. Demo af Action<T> delegate typen og hvordan en eksekveres med Square(4).
// 2. Demo af en Action-delegate-variabel brugt som parameter til Foo metoden. 

using System;

namespace CSmorningGym
{
    class ActionDelegate
    {
        static void Main(string[] args)
        {
            Action<int> Square = x => Console.WriteLine($"Kvadratet på tallet {x} er {x * x}");

            Square(4);
            //Foo(Square);
        }

        static void Foo(Action<int> calc)
        {
            Console.WriteLine("Indtast et tal");
            int tal = Convert.ToInt32(Console.ReadLine());
            calc(tal);
        }
    }
}
