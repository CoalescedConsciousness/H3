using DAL.Entities;
using DAL.Helpers;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using Webshop.Pages;

namespace Webshop.ViewComponents
{
    public class CartCountViewComponent : ViewComponent
    {
        public List<Item> cart { get; set; }

        public IViewComponentResult Invoke()
        {
            cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            var x = 0;
            if (cart != null)
            {
                foreach(var item in cart)
                {
                    x += item.Quantity;
                }
            }                
                
            return View(x);
        }
    }
}
