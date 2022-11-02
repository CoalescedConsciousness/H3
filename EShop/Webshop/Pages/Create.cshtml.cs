using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using DAL.Entities;
using ServiceLayer;

namespace Webshop.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IProductService _context;

        public CreateModel(IProductService context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            CategoryOptions = new SelectList(_context.GetCategories(), nameof(Category.Id), nameof(Category.Name));
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }
        public SelectList CategoryOptions { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Add(Product);
            _context.Save();

            return RedirectToPage("./Index");
        }
    }
}
