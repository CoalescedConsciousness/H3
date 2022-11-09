using Webshop.DAL.Models;

namespace Webshop.Services
{
    public interface ICustomerService
    {
        public Task<Customer> GetAsync(int Id);
        public Task<Customer> GetByMailAsync(string mail);
        public Task CreateAsync(Customer customer);
        public Task EditAsync(Customer customer);
        public Task DeactivateAsync(int Id, bool state);
        public Task RemoveAsync(Customer customer);
    }
}
