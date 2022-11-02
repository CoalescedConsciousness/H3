using DAL.Entities;
using ServiceLayer.Models;
using System.Collections;
using System.Linq;

namespace ServiceLayer
{
    public interface IProductService
    {
        IQueryable<Product> GetProducts();
        IQueryable<Product> GetProductsByName(string name = null);
        public ProductViewModel GetProductsByName(string searchTerm, int currentPage, int pageSize);
        public ProductViewModel GetProductsByName(string searchTerm, int currentPage, int pageSize, string CategoryName = null);
        Product GetProductById(int productId);
        Product Update(Product upProduct);
        Product Add(Product nProduct);
        Product Delete(int id);
        IQueryable<Category> GetCategories();

        int ProductCount();
        int Save();
    }
}