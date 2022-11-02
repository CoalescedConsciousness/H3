// Eksemplet viser oprettelsen af en delegate-type, som der oprettes en variabel af og initialiseres med en metode. 
// Derefter kaldes metoden ved at invoke delegaten, først explicit og derefter implicit.
// Metode-referencen flyttes "on the fly"

using System;

namespace CsharpExercises
{
    delegate int CalcDelegate(int x, int y);                        // Oprettelse af Delegate typen

    class DelegateAsMethodPointer
    {
        static void Main()
        {
            CalcDelegate myCalcDelegate = new CalcDelegate(Add);    // Oprettelse af Delegate variablen
            Console.WriteLine(myCalcDelegate.Invoke(3, 7));         // Explicit Invoke af Delegate variablen

            myCalcDelegate = Subtract;                              // Forenklet oprettelse af Delegate variablen
            Console.WriteLine(myCalcDelegate(10, 6));               // Explicit Invoke af Delegate variablen
        }

        private static int Add(int tal1, int tal2)                  // Add-metoden, der matcher CalcDelegate
        {
            return tal1 + tal2;
        }

        private static int Subtract(int tal1, int tal2)             // Subtract-metoden, der matcher CalcDelegate
        {
            return tal1 - tal2;
        }
    }
}
