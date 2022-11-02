using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class SaleOrder
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [Column(TypeName = "Decimal(8,2)")]
        public int? TotalPrice { get; set; }

        // m2m
        public IEnumerable<Product> Products { get; set; }
        
        // m2o
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        // o2o
        public Cart Cart { get; set; }
    }
}
