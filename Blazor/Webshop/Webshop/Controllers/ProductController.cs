using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webshop.DAL.Models;
using Webshop.Data;
using Webshop.Services;

namespace Webshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _context;

        public ProductController(IProductService context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("all")]
        public async Task<List<Product>> GetProducts()
        {
            return await _context.GetAllAsync();
        }
        

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.GetAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        //// PUT: api/Products/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }


            try
            {
                await _context.EditAsync(product);
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (product == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            await _context.CreateAsync(product);

            return Ok("Created");
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _context.RemoveAsync(product);

            return NoContent();
        }

    }
}
