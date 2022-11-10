using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webshop.DAL.Models;
using Webshop.DTO;
using Webshop.Services;

namespace Webshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _context;

        public OrderController(IOrderService context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDto order)
        {
            await _context.CreateAsync(order);
            return Ok("Created");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.GetAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }
    }
}