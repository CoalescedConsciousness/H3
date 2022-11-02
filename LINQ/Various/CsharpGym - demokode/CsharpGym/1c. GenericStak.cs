// En generic stack, der types med henholdsvis Int og Double.
// Bemærk at der nu ikke kræves typecasting ved pop af værdier.
// Ref. An Introduction to C# Generics
// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/

using System;

namespace LINQexercises
{
    class GenericStak
    {
        static void Main(string[] args)
        {
            Stak<int> minStak = new Stak<int>(3);
            minStak.Push(7);
            minStak.Push(9);
            minStak.Push(13);
            int tal1 = minStak.Pop(); 
            int tal2 = minStak.Pop();
            int tal3 = minStak.Pop();
            Console.WriteLine("Talrækken er: {0} {1} {2}", tal1, tal2, tal3);

            Stak<double> minDoubleStak = new Stak<double>(3);
            minDoubleStak.Push(7.8);
            minDoubleStak.Push(9.3);
            minDoubleStak.Push(13.1);
            double tal4 = minDoubleStak.Pop();
            double tal5 = minDoubleStak.Pop();
            double tal6 = minDoubleStak.Pop();
            Console.WriteLine("\nTalrækken er: {0} {1} {2}", tal4, tal5, tal6);
        }
    }

    class Stak<T>
    {
        T[] items;
        int stackpointer = 0;
        int arraySize;

        public Stak(int size)
        {
            items = new T[size];
            arraySize = size;
        }

        public void Push(T item)
        {
            items[stackpointer] = item;
            ++stackpointer;     
        }

        public T Pop()
        {
            --stackpointer; 
            if (stackpointer < 0)
            {
                throw new InvalidOperationException("Stak er tom");
            }
            return items[stackpointer];
        }
    }
}
