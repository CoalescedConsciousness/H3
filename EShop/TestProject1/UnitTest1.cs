using DAL;
using EShop;
using Microsoft.EntityFrameworkCore;
using NuGet.Frameworks;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Main()
        {
            var opt = new DbContextOptionsBuilder<EfCoreContext>()
                .UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = EShopDB; Trusted_Connection = True; ");

            using (var context = new EfCoreContext())
            {
                context.Database.EnsureCreated();
                var so = context.SaleOrders.Where(x => x.Id == 1);
                Assert.Single(so);

            }
        }
    }
}