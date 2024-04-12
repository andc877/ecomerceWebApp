using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomerceWebAPIs.Models
{
    public class Subscriptions
    {
        [Key]
        public int SubscriptionID { get; set; }

        [ForeignKey("Users")]
        public int UserID { get; set; }

        [ForeignKey("Plans")]
        public int PlanID { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string Status { get; set; } // Active, Inactive, Suspended

        [MaxLength(50)]
        public string PaymentMethod { get; set; } // Payment method used for subscription

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual Users User { get; set; }
        public virtual Plans Plan { get; set; }
    }
}
