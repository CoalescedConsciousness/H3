// Demo af en none-generic Stack-klasse, der er typet til kun at kunne tage imod integers
// Stack-klassen kaldes også LIFO (Last IN First Out)

using System;

namespace LINQexercises
{
    class IntStak
    {
        static void Main(string[] args)
        {
            Stak minStak = new Stak(3);
            minStak.Push(7);
            minStak.Push(9);
            minStak.Push(13);
            
            int tal1 = minStak.Pop();
            int tal2 = minStak.Pop();
            int tal3 = minStak.Pop();
            Console.WriteLine("Talrækken er: {0} {1} {2}", tal1, tal2, tal3);
        }
    }

    class Stak
    {
        int[] items;
        int stackpointer = 0;
        int arraySize;

        public Stak(int size)
        {
            items = new int[size];
            arraySize = size;
        }

        public void Push(int item)
        {
            items[stackpointer] = item;
            ++stackpointer;     
        }

        public int Pop()
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
