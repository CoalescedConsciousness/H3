// A. Ved hjælp af LINQbooks projektet laves en query, der henter alle de bøger som er udgivet af forlaget ”FunBooks”, sorteret stigende efter pris. 
//    Benyt Select til at beskære resulatet, således at det kun er Title, der udlæses i foreach løkken
// B. Lav en query, der henter alle de bøger som er på over 100 sider, sorteret stigende efter titel. 
//    Her skal ikke benyttes en Select, men udlæsningen af Title og PageCount tilpasses i en foreach
// C. Lav den samme query igen, men benyt denne gang en anonymous type til at beskære resultatet, så det bliver nemt at udlæse Title og PageCount. 
//    Kald de nye properties: Titel og Sideantal.

using LINQbooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace LINQbooksOpgaver
{
    class Opgave1
    {
        static void Main(string[] args)
        {
            //3
            //GetPublisher();
            //PageQuery(100);
            //PageQuerySimple(100);
            //Break();
            //QGetPublisher();
            //QPageQuery(100);
            //QPageQuerySimple(100);

            // 4
            AggregateBooksFirst();
            Console.WriteLine();
            FindTwoMostExpensive();
            Console.WriteLine();
            FindReviewedBooks();
            Console.WriteLine();
            BookBySubjects();


            Console.ReadKey();

        }

        #region Opgave 3
        // 3.1 LINQ Syntax
        static void GetPublisher()
        {
            Console.WriteLine("Getting Publishers");
            var res = SampleData.Books.Where(x => x.Publisher.Name == "FunBooks").OrderBy(x => x.Price);
            foreach (Book b in res)
                Console.WriteLine("{0}", b.Title);
            Console.WriteLine("Done...");
        }
        static void PageQuery(int pages)
        {
            var res = SampleData.Books.Where(x => x.PageCount > pages).OrderBy(x => x.Title).Take(100);
            foreach (Book b in res)
            {
                Console.WriteLine("{0}, {1}", b.Title, b.PageCount);
            }
        }
        static void PageQuerySimple(int pages)
        {
            var res = SampleData.Books.Where(x => x.PageCount > pages).OrderBy(x => x.Title).Take(100).Select(x => new TempBook
            {
                Titel = x.Title,
                Sideantal = x.PageCount

            });
            foreach (var b in res)
            {
                Console.WriteLine(b.Titel);
            }
        }
        

        // 3.2. Query Syntax 
        static void QGetPublisher()
        {
            var query =
                from b in SampleData.Books
                where b.Publisher.Name == "FunBooks"
                orderby b.Price ascending
                select new
                {
                    b.Title,
                };
            foreach (var q in query)
            {
                Console.WriteLine(q.Title);
            }
        }
        static void QPageQuery(int pages)
        {
            Console.WriteLine("Getting books by Pagecount");
            var q =
                from b in SampleData.Books
                where b.PageCount >= pages
                orderby b.Title ascending
                select b;

            foreach (var x in q)
            {
                Console.WriteLine("{0}, {1}", x.Title, x.PageCount);
            }
            Console.WriteLine("Done..");
        }
        static void QPageQuerySimple(int pages)
        {
            Console.WriteLine("Getting books..");
            var q =
                from b in SampleData.Books
                where b.PageCount >= pages
                orderby b.Title ascending
                select new TempBook()
                {
                    Titel = b.Title,
                    Sideantal = b.PageCount,
                };
            foreach (var x in q)
            {
                Console.WriteLine("{0}, {1}", x.Titel, x.Sideantal);
            }
        }
        #endregion
        #region Opgave 4
        // 4.1 Aggregate
        static void AggregateBooksFirst()
        {
            Console.WriteLine("Finding books that are over 100 pages, for less than 30:..");

            var res = SampleData.Books.Where(x => x.PageCount > 100 && x.Price < 30).OrderBy(x => x.Title).ThenByDescending(x => x.Price).ToList();
            foreach (var r in res)
            {
                Console.WriteLine("{0}, {1}, {2}", r.Title, r.PageCount, r.Price);
            }
        }
        static void FindTwoMostExpensive()
        {
            Console.WriteLine("Finding two most expensive books...");
            var res = SampleData.Books.OrderByDescending(x => x.Price).Take(2).Select(x => new { x.Title, x.Price });
            foreach (var r in res)
            {
                Console.WriteLine("{0} NON-DESCRIPT CURRENCY \t {1}", r.Price, r.Title);
            }
        }
        static void FindReviewedBooks()
        {

            var res =
                SampleData.Books.Where(x => x.Reviews.Count() >= 1).Select(x => new
                {
                    x.Title,
                    x.Reviews,
                });

            foreach (var r in res)
            {
                Console.WriteLine($"{r.Title}");
                foreach (var review in r.Reviews)
                {
                    Console.WriteLine($"\t-{review.User.Name}: \t {review.Comments}");
                }
            }
            
        }
        // 4.2
        static void BookBySubjects()
        {
            var res =
                SampleData.Books.GroupBy(x => x.Subject).Select(
                    g => new
                    {
                        Subject = g.Key,
                        Books = SampleData.Books.Where(x => x.Subject == g.Key).Select(x => x).OrderBy(x => x.Isbn)
                    });
            foreach (var item in res)
            {
                Console.WriteLine("--");
                Console.WriteLine($"{item.Subject}:");
               
                if (item.Books != null)
                {
                    foreach (var b in item.Books)
                    {
                        Console.WriteLine($"\t{b.Isbn}: {b.Title}");
                    }

                }
            }
        }
        #endregion

        #region Helpers
        static void Break()
        {
            Console.WriteLine("//////");
            Console.WriteLine("//////");
            Console.WriteLine("//////");
        }
        #endregion
    }

    #region Various
    class TempBook 
    {
        public string Titel { get; set; }
        public int Sideantal { get; set; }

    }
    #endregion
}
