using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;
using System.Drawing;

namespace Webshop.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        public static IProductService _product { get; set; }
        public ShopController(IProductService product)
        {
            _product = product;
        }

        [Route("products")]
        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            var products = _product.GetProducts();
            foreach (var x in products)
            {
                Console.WriteLine(x.Name);
            }
            return products;
        }

        [Route("products/{id}")]
        [HttpGet]
        public ActionResult GetProduct(int id)
        {
            var product = _product.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        } 

        [Route("products/add")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Product> Create(Product product)
        {
            _product.Add(product);
            _product.Save();
            return Ok(product);
        }

    }
}
