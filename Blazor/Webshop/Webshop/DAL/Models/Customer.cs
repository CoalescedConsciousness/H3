using Microsoft.AspNetCore.Components.Routing;

namespace Webshop.DAL.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Mail { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public int Zip { get; set; }
        public string City { get; set; }
    }
}
