// Stak-klassen er nu omskrevet til at arbejde med object-typen og kan derfor
// gemme alle typer. Men prisen er typecasting, når værdierne poppes ud af stacken

using System;

namespace LINQexercises
{
    class ObjectStak
    {
        static void Main(string[] args)
        {
            Stak minStak = new Stak(3);
            minStak.Push(7.1);
            minStak.Push(9.7);
            minStak.Push(13.5);

            double tal1 = (double)minStak.Pop();  // kræver en cast fra object til double
            double tal2 = (double)minStak.Pop();
            double tal3 = (double)minStak.Pop();
            Console.WriteLine("Talrækken er: {0} {1} {2}", tal1, tal2, tal3);
        }
    }

    class Stak
    {
        object[] items;
        int stackpointer = 0;
        int arraySize;

        public Stak(int size)
        {
            items = new object[size];
            arraySize = size;
        }

        public void Push(object item)
        {
            items[stackpointer] = item;
            ++stackpointer;     
        }

        public object Pop()
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
