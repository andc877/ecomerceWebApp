using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomerceWebAPIs.Models
{
    public class Images
    {
        [Key]
        public int ImageID { get; set; }

        [ForeignKey("Products")]
        public int ProductID { get; set; }

        [Required]
        [MaxLength(255)]
        public string ImageUrl { get; set; }

        [MaxLength(255)]
        public string AltText { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation property
        public virtual Products Product { get; set; }
    }
}
