// 1. Lav Calculator programmet om, så der benyttes Standard Delegate typer
// 2. Lav eksemplet herunder, men benyt ikke Predicate delegate typen, 
//      men en af de andre indbyggede typer.Du kan evt.lave et simpelt ”Gæt et tal”:
//          Predicate<int> equalsOne = x => x == 42;
// 3. Lav en delegate variabel med en Lambda expression, der kan modtage et beløb kaldet udenMoms 
//      af typen int, lægger moms til og returnere resultatet som en double type. 
//      Benyt en indbygget standard Delegate type.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQexercises
{
    class Opgave_4
    {
        public static void Menu()
        {
            Console.WriteLine("-----------44444------------------");
            Console.WriteLine("Du kan vælge følgende beregninger:");
            Console.WriteLine("+ Addition");
            Console.WriteLine("- Subtraktion");
            Console.WriteLine("x Afslut");
            Console.WriteLine("----------------------------------");
        }
        static void Main4(string[] args)
        {
            Menu();
            ConsoleKeyInfo keyinfo = new ConsoleKeyInfo();
            do
            {
                keyinfo = Console.ReadKey(true);

                switch (keyinfo.KeyChar)
                {
                    case '+':
                        Func<int, int, int> add = (x, y) => x + y;
                        Console.WriteLine("First number:");
                        int x = Convert.ToInt32(Console.ReadKey());
                        Console.WriteLine("Second number:");
                        int y = Convert.ToInt32(Console.ReadKey());
                        Console.WriteLine(add(x,y));
                        break;
                    case '-':
                        Func<int, int, int> sub = (x, y) => x + y;
                        Console.WriteLine("First number:");
                        int xSub = Convert.ToInt32(Console.ReadKey());
                        Console.WriteLine("Second number:");
                        int ySub = Convert.ToInt32(Console.ReadKey());
                        Console.WriteLine(sub(xSub, ySub));
                        break;
                }
                Menu();
            }
            while (keyinfo.KeyChar != 'x');
        }
    }
}
