using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace EcomerceWebAPIs.Models
{
    public class PlanPrice
    {
        [Key]
        public int PlanPriceID { get; set; }

        [ForeignKey("Plans")]
        public int PlanID { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime EffectiveDate { get; set; }  // Assuming this is the date when the price becomes effective

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation property
        public virtual Plans Plan { get; set; }
    }
}
