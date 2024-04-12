using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomerceWebAPIs.Models
{
    public class Orders
    {
        [Key]
        public int OrderID { get; set; }

        [ForeignKey("Users")]
        public int UserID { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation property
       // public virtual Users User { get; set; }
    }
}
