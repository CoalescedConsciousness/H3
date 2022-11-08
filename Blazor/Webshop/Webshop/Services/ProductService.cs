using Microsoft.EntityFrameworkCore;
using Webshop.Data;
using Webshop.DAL.Models;

namespace Webshop.Services
{
    public class ProductService : IProductService
    {
        private readonly WebshopContext _context;

        public ProductService(WebshopContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
        }

        public Task DeactivateAsync(int Id, bool state)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Product.ToListAsync();
        }

        public Task<List<Product>> GetAllAsync(int page, int size)
        {
            return _context.Product.ToListAsync();
        }
        public async Task RemoveAsync(Product product)
        {
            _context.Remove(product);
            await _context.SaveChangesAsync();

        }
        public async Task<Product> GetAsync(int Id)
        {
            return await _context.Product.FindAsync(Id);
        }

    }
}
