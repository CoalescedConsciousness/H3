using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required]
        public string Name { get; set; }
        
        [Column(TypeName = "Decimal(8,2)")]
        public decimal Price { get; set; }

        public string Reference { get; set; }

        public bool? Image { get; set; }

        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        
        
        public IEnumerable<SaleOrder>? SaleOrders { get; set; }

        // Additions after the fact:
        // Sale Orders?
        
    }
}
