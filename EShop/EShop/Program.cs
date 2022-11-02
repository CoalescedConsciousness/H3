using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace EShop
{
    class Program
    {
        static void Main(string[] args)
        {

            //AddSaleOrder();
            GetCustomerName();
            GetSaleOrders();
            //DEPRECATED:GetProductCategories();
        }
        static void AddSaleOrder()
        {
            using (var context = new EfCoreContext())
            {
                
                Customer c1 = context.Customers.Single(c => c.Id == 1);
                
                var p1 = context.Products.Where(p => p.Name.Contains(" 1")).ToList();
                SaleOrder so1 = new SaleOrder { Name = "SO00003" };
                
                so1.Customer = c1;
                Console.WriteLine(so1.Customer);
                so1.CustomerId = c1.Id;

                context.SaleOrders.Add(so1);
                context.SaveChanges();

            }
        }

        // Hardcoded ID for now
        static void GetCustomerName()
        {
            using (var context = new EfCoreContext())
            {
                var so = context.SaleOrders.Include(x => x.Customer).Single(c => c.Id == 3);
                Console.WriteLine(so.CustomerId);
                Console.WriteLine(so.Customer.Name);
            }
        }
        static void GetSaleOrders()
        {
            using (var context = new EfCoreContext())
            {
                var sos = context.SaleOrders.OrderBy(x => x.Id).ToList();
                foreach (var so in sos)
                {
                    Console.WriteLine($"ID {so.Id} \t Sale Order: {so.Name}");
                }
            }
        }

        //static void GetProductCategories()
        //{
        //    using (var context = new EfCoreContext())
        //    {
        //        var prod = context.Products.Include(x => x.Category).ToList();
        //        foreach (var p in prod)
        //        {
        //            if (p.Category != null) 
        //            {
        //                Console.WriteLine(p.Category.Name); 
        //            };
        //        }
        //    }
        //}
   
    }
}