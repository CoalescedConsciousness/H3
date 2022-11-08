namespace Webshop.DAL.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public int Zip { get; set; }
        public string City { get; set; }
        public IEnumerable<CustomerLocation> Locations { get; set; }
    }
}
