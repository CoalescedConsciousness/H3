using Microsoft.AspNetCore.Mvc;
using ServiceLayer;

namespace Webshop.ViewComponents
{
    public class ProductCountViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public ProductCountViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var x = _productService.ProductCount();
            return View(x);
        }
    }
}
