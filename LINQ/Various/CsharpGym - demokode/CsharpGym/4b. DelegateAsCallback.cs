using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQexercises
{
    delegate int CalcDelegate(int x, int y);                        // Oprettelse af Delegate typen

    class DelegateAsCallback
    {
        static void Main(string[] args)
        {
            Menu();
            ConsoleKeyInfo keyinfo = new ConsoleKeyInfo();
            do
            {
                keyinfo = Console.ReadKey(true);

                switch (keyinfo.KeyChar)
                {
                    case '+':
                        Calculate(Add);           
                        break;
                    case '-':
                        Calculate(Subtract);
                        break;
                }
                Menu();
            }
            while (keyinfo.KeyChar != 'x');
        }

        static void Calculate(CalcDelegate calc)
        {
            Console.WriteLine("Indtast tal 1");
            int tal1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Indtast tal 2");
            int tal2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Result = {calc(tal1, tal2)}");
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
