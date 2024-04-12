using System.ComponentModel.DataAnnotations;

namespace EcomerceWebAPIs.Models
{
    public class Categories
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
