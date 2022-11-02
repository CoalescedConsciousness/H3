using System;

namespace LINQexercises
{
    delegate int CalcDelegate(int x, int y);

    class AnonymousMethod
    {
        static void Main()
        {
            CalcDelegate myAddDelegate = delegate (int tal1, int tal2)
            {
                return tal1 + tal2;
            };

            Console.WriteLine(myAddDelegate(3, 7));
        }
    }
}
