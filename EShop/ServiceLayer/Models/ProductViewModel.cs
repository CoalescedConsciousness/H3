using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace ServiceLayer.Models
{
    public class ProductViewModel
    {
        public List<Product> Products { get; set; }
        public int TotalCount { get; set; }
    }
}
