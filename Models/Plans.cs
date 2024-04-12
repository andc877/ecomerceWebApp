using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcomerceWebAPIs.Models
{
    public class Plans
    {
        [Key]
        public int PlanID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [ForeignKey("PricePlan")]
        public decimal PlanPriceID { get; set; }

        [Required]
        public string Duration { get; set; } // You can refine this further based on your requirements, e.g., using TimeSpan or an enum for duration types

        public virtual PlanPrice PlanPrice { get; set; }
        // Add other properties as needed based on your requirements

        public DateTime CreatedDate { get; set; } = DateTime.Now; // Automatic setting of CreatedDate to current date and time
    }
}
