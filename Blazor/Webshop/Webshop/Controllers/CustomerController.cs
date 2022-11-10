using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Webshop.DAL.Models;
using Webshop.Services;

namespace Webshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _context;

        public CustomerController(ICustomerService context)
        {
            _context = context;
        }

        [HttpPost]
        //[Route("create")]
        public async Task<IActionResult> CreateCustomer(Customer customer)
        {
            await _context.CreateAsync(customer);

            return Ok("Created");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.GetAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }
        [HttpGet]
        [Route("email/{mail}")]
        public async Task<Customer> GetByMail(string mail)
        {
            return await _context.GetByMailAsync(mail);
        }

    }
}
