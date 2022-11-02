using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Queries
{
    // make Where operator.
    // static Extension method (Hvor()); iterates collection, builds List<T> with items that live up to constraints, and returns entire collection.
    // Same result as assignment 1?
    static class MyLinq
    {
        public static List<T> MoviesToList<T>(this IEnumerable<T> movieArr, Func<T, bool> pred)
        {
            var res = new List<T>();

            foreach (var x in movieArr)
            {
                if (pred(x))
                {
                    res.Add(x);
                }
            }
            return res;
        }
    }
}
