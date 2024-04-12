using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomerceWebAPIs.Models
{
    public class ProductPrice
    {
        [Key]
        public int ProductPriceID { get; set; }

        [ForeignKey("Products")]
        public int ProductID { get; set; }

        [Required]
        public decimal Price { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation property
      //  public virtual Products Product { get; set; }
    }
}
