using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entities;
using ServiceLayer;
using Microsoft.Extensions.FileProviders;

using System.ComponentModel;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Webshop.Pages
{
    public class EditModel : PageModel
    {
        //private readonly DAL.EfCoreContext _context;
        private readonly IProductService _context;
        public EditModel(IProductService context)
        {
            _context = context;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        [BindProperty]
        [DisplayName("File")]
        public IFormFile? formFile { get; set; }

        public SelectList CategoryOptions { get; set; }
        [BindProperty]
        public int SelectedCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.GetProducts() == null)
            {
                return NotFound();
            }

            var product =  _context.GetProductById(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            Product = product;
            SelectedCategory = (int)Product.CategoryId;
            CategoryOptions = new SelectList(_context.GetCategories(), nameof(Category.Id), nameof(Category.Name));
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<IActionResult> OnPostAsync()
        {
            if (SelectedCategory != null)
            {
                Product.CategoryId = SelectedCategory;
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Product.Id > 0)
            {
                await UploadFetchImageAsync(Product.Id);
                _context.Update(Product);
            }
            else
            {
                _context.Add(Product);
                await UploadFetchImageAsync(Product.Id);
            }

            try
            {
                _context.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.GetProductById(Product.Id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            TempData["Message"] = "Product saved!";
            return RedirectToPage("./Edit", new { Id = Product.Id });
        }


        public async Task<IActionResult> UploadFetchImageAsync(int id)
        {
            //var product = _context.GetProductById(id);
            if (formFile?.Length > 0)
            {
                var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img")).Root + $@"{id}.jpg";
                
                using (var stream = System.IO.File.Create(filepath))
                {
                    await formFile.CopyToAsync(stream);
                }
                
                Product.Image = true;
            }
            else
            {
                Product.Image = false;
            }
            return Page();
        }
    }
}
