using System;
using System.Collections.Generic;
using System.Linq;

namespace Queries
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movies = new List<Movie>
            {
                new Movie { Title = "The Reader", Rating = 7.6f, Year = 2008 },
                new Movie { Title = "As Good as It Gets", Rating = 7.7f, Year = 1997 },
                new Movie { Title = "The Bucket List", Rating = 7.4f, Year = 2007 },
                new Movie { Title = "Star Wars V", Rating = 8.7f, Year = 1980 },
                new Movie { Title = "Oblivion", Rating = 7.0f, Year = 2013}
            };

            GetMovies(movies); 
            var q = movies.MoviesToList(x => x.Year > 2000);
            foreach (var m in q) { Console.WriteLine(m.Title); }
            Console.ReadKey();
        }

        // Films after 2000, Descending sort on Rating, print Title and Year (use LINQ operator)
        static void GetMovies(List<Movie> movies)
        {
            var q = movies.Where(x => x.Year > 2000).OrderByDescending(y => y.Rating);
            foreach (Movie m in q)
            {
                Console.WriteLine("{0} // {1}", m.Title, m.Year);
            }
        }
    }
}
