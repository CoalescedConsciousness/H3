using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Webshop.DAL.Models;

namespace Webshop.Data
{
    public class WebshopContext : DbContext
    {
        public WebshopContext (DbContextOptions<WebshopContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            int pCount = 10;
            for (int i = 1; i < pCount; i++)
            {
                builder.Entity<Product>().HasData(

                    new Product()
                    {
                        Id = i,
                        Name = $"Test Product {i}",
                        Price = i * 10,
                        IsActive = true,
                    });
            }
        }
    }
}
