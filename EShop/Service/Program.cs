using DAL;
using EShop;
using Microsoft.EntityFrameworkCore;

namespace Service

{
    public class ShopService
    {
        private EfCoreContext _context;

        public ShopService(EfCoreContext context)
        {
            _context = context;
        }
    }
}