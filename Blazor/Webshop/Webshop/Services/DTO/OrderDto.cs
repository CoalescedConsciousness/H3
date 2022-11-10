using Webshop.DAL.Models;

namespace Webshop.DTO
{
    public class OrderDto
    {
        public int Id { get; set; }
        public float Total { get; set; }
        public int CustomerId { get; set; }

    }
}
