using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFGetStarted.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        
        [NotMapped]
        public string Category { get; set; }

        public List<Post> Posts { get; } = new List<Post>();
    }
}