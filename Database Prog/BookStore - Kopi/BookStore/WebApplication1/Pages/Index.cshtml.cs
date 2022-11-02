using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DataLayer.EfCoreContext _context;

        public IndexModel(DataLayer.EfCoreContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Titles { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? BookAuthor { get; set; }

        //public async Task OnGetAsync()
        //{
        //    IQueryable<string> titleQuery = from x in _context.Books
        //                                    orderby x.Title
        //                                    select x.Title;
        //    var books = from x in _context.Books select x;

        //    if (!string.IsNullOrEmpty(SearchString))
        //    {
        //        books = books.Where(x => x.Title.Contains(SearchString));
        //    }


        //    if (_context.Books != null)
        //    {
        //        Book = await _context.Books.ToListAsync();
        //    }

        //    Titles = new SelectList(await titleQuery.Distinct().ToListAsync());
        //    Book = await books.ToListAsync();
        //}
    }
}
