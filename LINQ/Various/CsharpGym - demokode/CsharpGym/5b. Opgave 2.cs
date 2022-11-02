// Redigér Calculator eksemplet 5b og erstat Add og Subtract metoder med anonymous metoder.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LINQexercises
{
    delegate int CalcDelegate(int x, int y);                        // Oprettelse af Delegate typen

    class DelegateAsCallback
    {
        static void Main2(string[] args)
        {
            Menu();
            ConsoleKeyInfo keyinfo = new ConsoleKeyInfo();
            do
            {
                keyinfo = Console.ReadKey(true);

                switch (keyinfo.KeyChar)
                {
                    case '+':
                        Calculate("a");
                        break;
                    case '-':
                        Calculate("s");
                        break;
                }
                Menu();
            }
            while (keyinfo.KeyChar != 'x');
        }

        static void Calculate(string x)
        {
            Console.WriteLine(x);
            Console.WriteLine("Indtast tal 1");
            int tal1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Indtast tal 2");
            int tal2 = Convert.ToInt32(Console.ReadLine());
            switch (x)
            {
                case "a":
                    CalcDelegate add = (tal1, tal2) => { return tal1 + tal2; };
                    break;
                case "s":
                    CalcDelegate sub = (tal1, tal2) => { return tal1 - tal2; };
                    break;
            }
        }

        static int Add(int tal1, int tal2)           
        {
            return tal1 + tal2;
        }

        static int Subtract(int tal1, int tal2)     
        {
            return tal1 - tal2;
        }

        public static void Menu()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Du kan vælge følgende beregninger:");
            Console.WriteLine("+ Addition");
            Console.WriteLine("- Subtraktion");
            Console.WriteLine("x Afslut");
            Console.WriteLine("----------------------------------");
        }
    }
}
