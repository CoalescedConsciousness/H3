using Microsoft.AspNetCore.Mvc;

namespace RazorPagesMovie.ViewComopnents
{
	public class BookCountViewComponent : ViewComponent
    {
        private readonly Data.RazorPagesMovieContext _context;

        public BookCountViewComponent(Data.RazorPagesMovieContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var movies = from m in _context.Movie
                         select m;
            int count = movies.Count();
            return View(count);
        }
	
	}
}
