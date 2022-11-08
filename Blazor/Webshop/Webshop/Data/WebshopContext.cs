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

        public DbSet<Webshop.DAL.Models.Product> Product { get; set; } = default!;
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    Name = "Test Product",
                    Price = 10,
                    IsActive = true,
                }); 
        }
    }
}
