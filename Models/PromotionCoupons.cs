using System.ComponentModel.DataAnnotations;

namespace EcomerceWebAPIs.Models
{
    public class PromotionCoupons
    {
        [Key]
        public int PromotionID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Code { get; set; }

        [Required]
        public decimal Discount { get; set; }

        [Required]
        public DateTime Validity { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
