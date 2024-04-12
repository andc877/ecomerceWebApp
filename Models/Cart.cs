using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomerceWebAPIs.Models
{
    public class Cart
    {
        [Key]
        public int CartID { get; set; }

        [ForeignKey("Users")]
        public int UserID { get; set; }

        [ForeignKey("Products")]
        public int ProductID { get; set; }

        [Required]
        public int? Quantity { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual Users User { get; set; }
        public virtual Products Product { get; set; }
    }
}
