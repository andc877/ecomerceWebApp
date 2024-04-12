using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomerceWebAPIs.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailID { get; set; }

        [ForeignKey("Orders")]
        public int OrderID { get; set; }

        [ForeignKey("Products")]
        public int ProductID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PriceAtPurchase { get; set; }

       
        [Column(TypeName = "decimal(18,2)")]
        public decimal? ProductOriginalPrice { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation properties
       // public virtual Orders Order { get; set; }
       // public virtual Products Product { get; set; }
    }
}
