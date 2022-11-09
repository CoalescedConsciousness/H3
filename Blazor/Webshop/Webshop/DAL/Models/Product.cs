using System.ComponentModel.DataAnnotations;

namespace Webshop.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
       
        [Required]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }

        [Required]
        public bool IsActive { get; set; } = false;

    }
}
