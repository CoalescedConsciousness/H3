// Rigtig god artikel: http://blogs.msdn.com/b/charlie/archive/2008/01/31/expression-tree-basics.aspx

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;

namespace ExpressionTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> function = (a, b) => a + b;
            Console.WriteLine(function(3, 5));

            // Code is converted into a datastructor with nodes
            Expression<Func<int, int, int>> expression = (a, b) => a + b;
            Console.WriteLine(expression);
            Console.WriteLine("Param 1: {0}, Param 2: {1}", expression.Parameters[0], expression.Parameters[1]);
            BinaryExpression body = (BinaryExpression)expression.Body;
            ParameterExpression left = (ParameterExpression)body.Left;
            ParameterExpression right = (ParameterExpression)body.Right;
            Console.WriteLine(expression.Body);
            Console.WriteLine(" The left part of the expression: " +
              "{0}{4} The NodeType: {1}{4} The right part: {2}{4} The Type: {3}{4}",
              left.Name, body.NodeType, right.Name, body.Type, Environment.NewLine);

            // ExpressionTree is converted back again into Code
            int result = expression.Compile()(3, 5);
            Console.WriteLine(result);
        }
    }
}
