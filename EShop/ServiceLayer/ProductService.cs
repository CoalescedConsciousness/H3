using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class ProductService : IProductService
    {
        private readonly EfCoreContext _context;
        public ProductService(EfCoreContext context)
        {
            _context = context;
        }
        public IQueryable<Product> GetProducts()
        {
            return _context.Products;

        }

        
        public IQueryable<Product> GetProductsByName(string name = null)
        {
            return _context.Products.Where(x => string.IsNullOrEmpty(name) || x.Name.StartsWith(name))
                .OrderBy(x => x.Name);
        }
        public ProductViewModel GetProductsByName(string searchTerm, int currentPage, int pageSize)
        {
            ProductViewModel prodView = new ProductViewModel();
            var query = _context.Products.AsNoTracking();
            query = searchTerm != null ? query.Where(c => c.Name.ToLower().Contains(searchTerm.ToLower())).OrderBy(r => r.Name).Include(x => x.Category) : query;

            prodView.TotalCount = query.Count();

            prodView.Products = query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return prodView;
        }
        public ProductViewModel GetProductsByName(string searchTerm, int currentPage, int pageSize, string CategoryName)
        {
            ProductViewModel prodView = new ProductViewModel();
            var query = _context.Products.AsNoTracking();
            query = searchTerm != null ? query.Where(c => c.Name.ToLower().Contains(searchTerm.ToLower())).OrderBy(r => r.Name).Include(x => x.Category) : query;
            if (CategoryName != null)
            {
                query = query.Where(x => x.Category.Name == CategoryName);
            }
            

            prodView.TotalCount = query.Count();

            prodView.Products = query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return prodView;
        }

        public IQueryable<Category> GetCategories()
        {
            return _context.Categories;
        }
        public Product GetProductById(int productId)
        {
            return _context.Products.Where(x => x.Id == productId).FirstOrDefault();
        }

        public Product Update(Product uProduct)
        {
            _context.Products.Update(uProduct);
            return uProduct;
        }

        public Product Add(Product nProduct)
        {
            _context.Products.Add(nProduct);
            return nProduct;
        }

        public Product Delete(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }
            return product;
        }
    
        public int ProductCount()
        {
            return _context.Products.Count();
        }

        public int Save()
        {
            _context.SaveChanges();
            return 0;
        }
    }

    
}
