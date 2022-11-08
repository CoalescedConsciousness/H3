namespace Webshop.DAL.Models
{
    public class CustomerLocation
    {
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
