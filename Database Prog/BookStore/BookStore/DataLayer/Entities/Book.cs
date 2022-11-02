using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; }  
        public string? Description { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime PublishedOn { get; set; }
        
        public string? Publisher { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }


        //public string ImageUrl { get; set; }
        [DefaultValue(false)]
        public bool? SoftDeleted { get; set; }

        // Relations
        // (Principal; one (1) book owns multiple Reviews)
        // (One book can have one specific price)
        public List<Review> Reviews { get; set; }
        public PriceOffer PriceOffer { get; set; }

        // m2m (Author <-> BookAuthors <-> Book)
        public ICollection<Author> Author { get; set; }
        public List<BookAuthor> BookAuthors { get; set; }


    }
}
