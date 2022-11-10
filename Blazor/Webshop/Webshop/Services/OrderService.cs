using Webshop.DAL.Models;
using Webshop.Data;
using Webshop.DTO;

namespace Webshop.Services
{
    public class OrderService : IOrderService
    {
        private readonly WebshopContext _context;

        public OrderService(WebshopContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(OrderDto order)
        {
            Order realOrder = new()
            {
                CustomerId = order.CustomerId,
                Total = order.Total,
            };
            _context.Add(realOrder);
            await _context.SaveChangesAsync();
        }
        
        public async Task<Order> GetAsync(int Id)
        {
            return await _context.Orders.FindAsync(Id);
        }
    }
}
