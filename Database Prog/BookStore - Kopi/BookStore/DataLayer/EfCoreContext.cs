using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DataLayer
{
    public class EfCoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = default!;
        public DbSet<Author> Authors { get; set; }
        public DbSet<PriceOffer> PriceOffers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public EfCoreContext (DbContextOptions<EfCoreContext> options) : base(options) { }

        public EfCoreContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = BookStoreDb; Trusted_Connection = True; ")
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PriceOffer>().Property(offer => offer.NewPrice).HasPrecision(18, 2);
            
            // o2o via Fluent API
            modelBuilder.Entity<Book>()
                .HasOne(b => b.PriceOffer)
                .WithOne(b => b.Book)
                .HasForeignKey<PriceOffer>(b => b.BookId);

            modelBuilder.Entity<BookAuthor>().HasKey(k => new {k.BookId, k.AuthorId});

            // Seeds
            modelBuilder.Entity<Book>().HasData(
                new { BookId = 1, Title = "Refactoring", Description = "Improving the design of existing code", PublishedOn = DateTime.Parse("8/7/1999"), Price = (decimal)40 },
                new { BookId = 2, Title = "Patterns of Enterprise Application Architecture", Description = "Written in direct response to the stiff challenges", PublishedOn = DateTime.Parse("15/11/2002"), Price = (decimal)53 },
                new { BookId = 3, Title = "Domain - Driven Design", Description = "Linking business needs to software design", PublishedOn = DateTime.Parse("30/8/2003"), Price = (decimal)56 },
                new { BookId = 4, Title = "Quantum Networking", Description = "Entangled quantum networking provides faster - than - light data communications", PublishedOn = DateTime.Parse("1/1/2057"), Price = (decimal)220 }
                );

            modelBuilder.Entity<Author>().HasData(
                new { AuthorId = 1, Name = "Martin Fowler" },
                new { AuthorId = 2, Name = "Eric Evans" },
                new { AuthorId = 3, Name = "Future Person" }
                );

            modelBuilder.Entity<BookAuthor>().HasData(
                new {BookId = 1, AuthorId = 1},
                new {BookId = 1, AuthorId = 2},
                new {BookId = 2, AuthorId = 1},
                new {BookId = 3, AuthorId = 2},
                new {BookId = 4, AuthorId = 3}
                );

            modelBuilder.Entity<Review>().HasData(
                new {ReviewId = 1, BookId = 1, Comment = "Great book", NumStars = 3},
                new {ReviewId = 2, BookId = 1, Comment = "Boring book", NumStars = 1}
                );
        }
    }
}
