using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using News.Models;

namespace EFGetStarted
{
    public class NewsContext : DbContext
    {
        public DbSet<Item> NewsItems { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (Program.DoPrint)
            {
                options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=NewsDb;Trusted_Connection=True;")
                .EnableSensitiveDataLogging(true)
                .UseLoggerFactory(new ServiceCollection()
                    .AddLogging(builder => builder.AddConsole().
                    AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information))
                    .BuildServiceProvider().GetService<ILoggerFactory>());
            }
            else
            {
                options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=NewsDb;Trusted_Connection=True;");
            }
        }
    }
}