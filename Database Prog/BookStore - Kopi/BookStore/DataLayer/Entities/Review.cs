using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        [DefaultValue("Anonymous")]
        public string? VoterName { get; set; }
        public int NumStars { get; set; }
        public string Comment { get; set; }

        // Relations (Review depends on the Book reviewed)
        public int BookId { get; set; }
        public Book Book { get; set; }

    }
}
