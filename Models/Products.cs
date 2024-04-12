using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomerceWebAPIs.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }

        [Required]
        public string Description { get; set; }

        //[ForeignKey("ProductPrice")]
        //public decimal ProductPriceID { get; set; }

        
        public int? QuantityAvailable { get; set; }

        [ForeignKey("Categories")]
        public int CategoryID { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation property
        //public virtual Categories Category { get; set; }
        //public virtual ProductPrice ProductPrice { get; set; }

    }
}
