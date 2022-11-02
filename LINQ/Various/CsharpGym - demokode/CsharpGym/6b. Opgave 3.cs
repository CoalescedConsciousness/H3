/* Lav en delegate-type kaldet FullNameType, der kan benyttes til metoder, der tager et fornavn og et efternavn og returnerer en streng med det fulde navn
*  Opret en metode kaldet FullName, der matcher NullNameType
*  Opret en delegate-variabel, der peger på FullName metoden.Invoke metoden og udskriv resultatet.Lav eksemplet på alle 4 måder:
*       - Med den eksterne metode
*       - Med anonymous method og delegate
*       - Med Lambda statement
*       - Med Lambda expression
*/

using System;

namespace LINQexercises
{
    delegate string FullNameType(string fornavn, string efternavn);

    class Opgave_3
    {
        static void Main3(string[] args)
        {
            string testFirstName = "Name";
            string testSurname = "Surname";

            // Med ekstern metode
            Console.WriteLine(FullName(testFirstName, testSurname));

            // Med anonymous method og delegate
            FullNameType myName = delegate (string first, string last)
            {
                return first + last;
            };
            Console.WriteLine(myName(testFirstName, testSurname));

            // Med Lambda Statement
            FullNameType myNameStatement = (testFirstName, testSurname) =>
            {
                return testFirstName + " " + testSurname;
            };
            Console.WriteLine(myNameStatement(testFirstName, testSurname));

            // Med Lambda Expression
            FullNameType myNameExpression = (testFirstName, testSurname) => testFirstName + " " + testSurname;
            Console.WriteLine(myNameExpression(testFirstName, testSurname));
        }

        // Ekstern metode
       private static string FullName(string first, string last)
        {
            return first + " " + last;
        }
    }
}
