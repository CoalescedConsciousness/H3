using Webshop.DAL.Models;
using Webshop.DTO;

namespace Webshop.Services
{
    public interface IOrderService
    {
        public Task<Order> GetAsync(int Id);
        public Task CreateAsync(OrderDto order);

    }
}
