using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        // m2o (More products can be linked to a single category; allows for searching)
        public List<Product> Products { get; set; }
    }
}
