// C# Closures Explained: http://www.codethinked.com/c-closures-explained
using System;

namespace LINQexercises
{
    class Closure
    {
        static void Main()
        {
        string name = "Christina";

        // 1. Med explicit metode og parameteroverførsel
        Action<string> myFoo = Foo;
        myFoo(name);

        // 2. Med Inline metode og parameteroverførsel
        Action<string> myInlineFoo = n => Console.WriteLine("Hej " + n);
        myInlineFoo(name);


        // 3. Med Inline metode og Closure. Bemærk at Anonymous-method har adgang til 
        //      Main()'s variabel, der hedder name!
        Action myClosureFoo = () => Console.WriteLine("Hej " + name);
        myClosureFoo();
        }

        private static void Foo(string name)
        {
            Console.WriteLine("Hej " + name);
        }
    }
}
