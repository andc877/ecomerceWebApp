using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomerceWebAPIs.Models
{
    public class Inventory
    {
        [Key]
        public int InventoryID { get; set; }

        [ForeignKey("Products")]
        public int ProductID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }

        // Navigation property
        public virtual Products Product { get; set; }
    }
}
