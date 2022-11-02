// Debug koden og kør musen hen over var. 
// Compileren har fundet den korrekte type ved at kigge på 
// typen på højre side af lighedstegnet (Infer)

using System;
using System.Collections.Generic;

namespace LINQexercises
{
    class ImplicitlyTypedVariables
    {
        static void Main(string[] args)
        {
            var i = 12;
            var s = "Hello";
            var d = 1.0;
            var numbers = new[] { 1, 2, 3 };
            var process = new ProcessData();
            var processes = new Dictionary<int, ProcessData>();
        }
    }

    class ProcessData
    {
        public int Id { get; set; }
        public long Memory { get; set; }
        public string Name { get; set; }
    }
}
