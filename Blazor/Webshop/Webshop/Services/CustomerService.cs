using Webshop.DAL.Models;
using Webshop.Data;

namespace Webshop.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly WebshopContext _context;

        public CustomerService(WebshopContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetAsync(int Id)
        {
            return await _context.Customers.FindAsync(Id);
        }
        public async Task<Customer> GetByMailAsync(string mail)
        {
            var customer = _context.Customers.Where(x => x.Mail == mail).FirstOrDefault();
            return customer;
        }

        public async Task CreateAsync(Customer customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
        public async Task DeactivateAsync(int Id, bool state)
        { 
        }

        public async Task RemoveAsync(Customer customer)
        { 
        }
    }
}
