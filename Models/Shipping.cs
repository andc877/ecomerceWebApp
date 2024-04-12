using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomerceWebAPIs.Models
{
    public class Shipping
    {
        [Key]
        public int ShippingID { get; set; }

        [ForeignKey("Orders")]
        public int OrderID { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string ShippingMethod { get; set; }

        [Required]
        public decimal ShippingCost { get; set; }

        [Required]
        public DateTime EstimatedDeliveryDate { get; set; }

        [Required]
        public string TrackingNumber { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation property
        public virtual Orders Order { get; set; }
    }
}
