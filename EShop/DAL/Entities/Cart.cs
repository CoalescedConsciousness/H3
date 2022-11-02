using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Cart
    {
        public int Id { get; set; }
        //public int CustomerId { get; set; }
        //public Customer Customer { get; set; }
        
        public int SaleOrderId { get; set; }
        public SaleOrder SaleOrder { get; set; }

        public List<Product> Products { get; set; }
    }
}
