// Normalt kan en Anonymous Type kun anvendes indenfor den metode, hvor den oprettes.
// Men anvender man returtypen dynamic vil compileren under runtime bestemme den
//  aktuelle type - og der vises ikke nogen syntax error når koden skrives.
// Til gengæld opnår man selvfølgelig heller ikke Intellisense!

using System;
using System.Collections.Generic;

namespace LINQexercises
{
    class AnonymousTypes
    {
        static void Main(string[] args)
        {
            foreach (var item in CreatePersons())
            {
                Console.WriteLine($"{item.Fornavn} {item.Efternavn}: {item.Alder} år");
            }
        }

        static List<dynamic> CreatePersons()
        {
            return new List<dynamic>
            {
                 new { Fornavn = "Liza", Efternavn = "Nielsen", Alder = 34 },
                 new { Fornavn = "Christian", Efternavn = "Hansen", Alder = 22 }
            };
        }
    }
}
