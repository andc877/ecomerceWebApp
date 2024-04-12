using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomerceWebAPIs.Models
{
    public class Reviews
    {
        [Key]
        public int ReviewID { get; set; }

        [ForeignKey("Users")]
        public int UserID { get; set; }

        [ForeignKey("Products")]
        public int ProductID { get; set; }

        [Range(1, 5)] // Assuming the rating is between 1 and 5
        public int Rating { get; set; }

        [MaxLength(500)] // Adjust the maximum length as needed
        public string Comment { get; set; }

        public DateTime DatePosted { get; set; } = DateTime.Now;

        // Navigation properties
        public virtual Users User { get; set; }
        public virtual Products Product { get; set; }
    }
}
