using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomerceWebAPIs.Models
{
    public class Refunds
    {
        [Key]
        public int RefundID { get; set; }

        [ForeignKey("Orders")]
        public int OrderID { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [MaxLength(100)]
        public string Reason { get; set; }

        public DateTime RefundDate { get; set; } = DateTime.Now;

        public string Status { get; set; }  // Assuming this can be "Pending", "Approved", "Rejected", etc.

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation property
        public virtual Orders Order { get; set; }
    }
}
