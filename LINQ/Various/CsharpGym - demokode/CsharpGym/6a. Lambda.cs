using System;

namespace LINQexercises
{
    delegate int CalcDelegate(int x, int y);

    class Lambda
    {
        static void Main()
        {
            // Lambda Statement
            CalcDelegate myLambdaStatement = (tal1, tal2) =>
            {
                return tal1 + tal2;
            };

            Console.WriteLine(myLambdaStatement(3, 7));

            // Lambda Expression
            CalcDelegate myLambdaExpression = (tal1, tal2) => tal1 + tal2;

            Console.WriteLine(myLambdaExpression(3, 7));
        }
    }
}
