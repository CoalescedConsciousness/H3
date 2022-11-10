using System.Text.Json.Serialization;

namespace Webshop.DAL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public float? Total { get; set; }
        public int CustomerId { get; set; }

        [JsonIgnore]
        public Customer Customer { get; set; }
        public List<Product>? Products { get; set; }
    }
}
