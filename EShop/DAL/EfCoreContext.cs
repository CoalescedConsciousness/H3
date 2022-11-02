using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EfCoreContext : DbContext
    {
      

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SaleOrder> SaleOrders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = EShopDB; Trusted_Connection = True; ");
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //mb.Entity</*ProductSaleOrder*/>().HasKey(x => new { x.ProductId, x.SaleOrderId });
            mb.Entity<SaleOrder>().HasMany(x => x.Products).WithMany(x => x.SaleOrders);
            mb.Entity<SaleOrder>().HasOne(x => x.Customer).WithMany(x => x.SaleOrders);
            // Seeds
            mb.Entity<Category>().HasData(
                new { Id = 1, Name = "Category 1" },
                new { Id = 2, Name = "Category 2" }
                );
            
            mb.Entity<Customer>().HasData(
                new { Id = 1, Name = "Test Person 1", Address = "Test Address 1" }
                );
            mb.Entity<Product>().HasData(
                new { Id = 1, Name = "Product 1", Price = (decimal)10.00, Reference = "00001", CategoryId = 1 },
                new { Id = 2, Name = "Product 2", Price = (decimal)20.00, Reference = "00002", CategoryId = 1 },
                new { Id = 3, Name = "Product 3", Price = (decimal)30.00, Reference = "00003" }
                );

            //mb.Entity<ProductSaleOrder>().HasData(
            //    new { ProductId = 1, SaleOrderId = 1},
            //    new { ProductId = 2, SaleOrderId = 2},
            //    new { ProductId = 3, SaleOrderId = 1}
            //    );
            mb.Entity<SaleOrder>().HasData(
                new { Id = 1, Name = "SO0001", CustomerId = 1 },
                new { Id = 2, Name = "SO0002", CustomerId = 1 }
                );
        }
    }
}
