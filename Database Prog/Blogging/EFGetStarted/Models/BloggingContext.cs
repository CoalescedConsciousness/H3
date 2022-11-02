using EFGetStarted.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EFGetStarted
{
    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=BloggingDb;Trusted_Connection=True;")
            .EnableSensitiveDataLogging(true)
            .UseLoggerFactory(new ServiceCollection()
                .AddLogging(builder => builder.AddConsole().
                AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information))
                .BuildServiceProvider().GetService<ILoggerFactory>());


        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Blog>().HasData(
                new { BlogId = 2, Category = "Horsies!", Url = "www.eb.dk" }
                );

            mb.Entity<Post>().HasData(
                new { BlogId = 1, Content = "Test", PostId = 1, Title = "Test Title" });
            mb.Entity<Post>()
                .Property(b => b.DateCreated)
                .HasDefaultValueSql("getdate()");
     
        }
    }
}