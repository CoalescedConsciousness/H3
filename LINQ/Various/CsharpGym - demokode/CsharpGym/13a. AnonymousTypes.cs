// En klasse med et compiler-genereret navn
// og med properties oprettet af compileren ud fra initialiseringen.
// Syntaxen ligner Object Initializer, dog uden klassenavn
// Bemærk at brugen af var er en nødvendighed!
// Herunder oprettes person1 og person2 af samme klasse, mens person3 får en ny klasse pga. den ændrede rækkefølge:
using System;

namespace LINQexercises
{
    class AnonymousTypes
    {
        static void Main(string[] args)
        {
            var person1 = new { Fornavn = "Liza", Efternavn = "Nielsen", Alder = 34 };
            Console.WriteLine(person1.GetType());
            var person2 = new { Fornavn = "Christian", Efternavn = "Hansen", Alder = 22 };
            Console.WriteLine(person2.GetType());

            var person3 = new { Alder = 9, Efternavn = "Ella", Fornavn = "Olsen" };
            Console.WriteLine(person3.GetType());        
        }
    }
}
