namespace Webshop.DAL.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string Name { get; set; }
    }
}
