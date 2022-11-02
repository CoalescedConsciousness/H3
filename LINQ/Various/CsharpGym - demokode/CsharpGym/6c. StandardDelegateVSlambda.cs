using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQexercises
{
    class LambdaDelegates
    {
        static void Main(string[] args)
        {
            //////////////////////// ACTION = WITH NO INPUT PARAMETER - RETURNS VOID /////////////////////
            Action myActionNoParams = new Action(DisplayNoParams);  // Ikke nødvendigt at skrive new Action. Gøres ikke fremover!
            Action myActionNoParams1 = DisplayNoParams;
            myActionNoParams1();

            Action myActionNoParams2 = delegate()
            {
                Console.WriteLine("No params - Inline anonymous method with delegate");
            };
            myActionNoParams2();

            Action myActionNoParams3 = () => Console.WriteLine("No params - Inline anonymous method with Lambda Expression");
            myActionNoParams3();

            //////////////////////// ACTION = WITH STRING INPUT PARAMETER - RETURNS VOID /////////////////////
            Action<string> myActionParam1 = DisplayParams;
            myActionParam1("Input param - External method");

            Action<string> myActionParam2 = delegate(string param2)
            {
                Console.WriteLine(param2);
            };
            myActionParam2("Input param - Inline anonymous method with delegate");

            Action<string> myActionParam3 = s => Console.WriteLine(s);
            myActionParam3("Input param - Inline anonymous method with Lambda Expression");


            //////////////////////// FUNC = RETURN PARAMETER /////////////////////

            Func<DateTime> getDateTime = () => DateTime.Now;
            Console.WriteLine(getDateTime());

            Func<int, int> increment = x => x + 1;
            Console.WriteLine(increment(3));

            Func<int, int, int> sumInts = (x, y) => x + y;
            Console.WriteLine(sumInts(3, 4));

            Func<int, int, int> comparer = (x, y) =>
                {
                    if (x > y) return 1;
                    if (x < y) return -1;
                    return 0;
                };
            Console.WriteLine(comparer(4, 7));

            //////////////////////// PREDICATE = BOLEAN RETURN PARAMETER /////////////////////

            Predicate<int> equalsOne = x => x == 1;
            if (equalsOne(1))
            {
                Console.WriteLine("Betingelse opfyldt");
            }
        }

        //////////////////////// HELPER METHODS /////////////////////
        static void DisplayNoParams()
        {
            Console.WriteLine("No params - External method");
        }

        static void DisplayParams(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
