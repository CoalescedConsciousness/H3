using Webshop.DAL.Models;
using Webshop.Data;

namespace Webshop.Services
{
    public interface IProductService
    {
       
        public Task<List<Product>> GetAllAsync();
        public Task<Product> GetAsync(int Id);
        public Task<List<Product>> GetAllAsync(int page, int size);

        public Task CreateAsync(Product product);
        public Task EditAsync(Product product);
        public Task DeactivateAsync(int Id, bool state);

        public Task RemoveAsync(Product product);

        //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    }
}
