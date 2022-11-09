using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using ServiceLayer.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Webshop.Pages
{
    public class IndexModel : PageModel
    {
        
        private readonly ServiceLayer.IProductService _productService;
        public IndexModel(ServiceLayer.IProductService productService)
        {
            _productService = productService;
        }

        public IList<Product> Product { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Category { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? ProductCategory { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 10;

        public int Count { get; set; }

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        public enum PageSizeEnum
        {
            [Display(Name = "2")]
            _2 = 2,
            [Display(Name = "4")]
            _4 = 4,
            [Display(Name = "10")]
            _10 = 10,
        }


        public async Task OnGetAsync()
        {
            
            var products = _productService.GetProducts();
            Category = new SelectList(_productService.GetCategories().Select(x => x.Name));
            Product = await products.ToListAsync();

            ProductViewModel prodView;

            if (!string.IsNullOrEmpty(SearchString))
            {
                prodView = _productService.GetProductsByName(SearchString, CurrentPage, PageSize);
                Product = prodView.Products.ToList();
                Count = prodView.TotalCount;

            }
            if (!string.IsNullOrEmpty(ProductCategory))
            {
                prodView = _productService.GetProductsByName(SearchString, CurrentPage, PageSize, ProductCategory);
                Product = prodView.Products.ToList();
                var test = prodView.Products.Where(x => x.Category.Name == ProductCategory);
                Count = prodView.TotalCount;
            }
            
            
            
        }
    }
}
