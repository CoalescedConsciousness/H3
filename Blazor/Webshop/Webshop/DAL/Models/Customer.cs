using Microsoft.AspNetCore.Components.Routing;

namespace Webshop.DAL.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Mail { get; set; }
        public IEnumerable<CustomerLocation> Locations { get; set; }
    }
}
