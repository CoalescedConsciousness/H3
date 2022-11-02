using Microsoft.EntityFrameworkCore;
using DataLayer;
using DataLayer.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace QueryingData
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetAuthorReview();
            AddNewBookWithNewReview();
        }

        static void AddNewBookWithNewReview()
        {
            
            Book book = new Book { Title = "Test Book", PublishedOn = DateTime.UtcNow };
            Review review = new Review { NumStars = 5, Comment = "Great test book", VoterName = "Mr U Test" };
            using (var context = new EfCoreContext())
            {
                context.Books.Add(book);
                //context.Reviews.Add(review);
                context.SaveChanges();
                
                

                

            }
        }
        static void GetAuthorReview()
        {
            using (var context = new EfCoreContext())
            {
                var books = context.Books
                    .Include(ba => ba.BookAuthors)
                    .Include(b => b.Reviews)
                    .ToList();

                foreach (var b in books)
                {
                    Console.WriteLine($"ID: {b.BookId} \t Title: {b.Title} \t Price: {b.Price}");
                    Console.WriteLine("Authors:");
                    foreach (var a in b.BookAuthors)
                    {
                        Console.WriteLine(a.Author);
                    }
                    Console.WriteLine("Reviews:");
                    foreach (var r in b.Reviews)
                    {
                        Console.WriteLine($"Stars: {r.NumStars} \t Review: {r.Comment}");
                    }

                }
            }

        }
    }
}