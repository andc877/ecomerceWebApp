using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomerceWebAPIs.Models
{
    public class Analytics
    {
        [Key]
        public int AnalyticsID { get; set; }

        [Required]
        [MaxLength(100)]
        public string PageName { get; set; }

        [ForeignKey("Users")]
        public int UserID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Action { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;

        // Additional data, if needed
        // public string AdditionalData { get; set; }

        // Navigation property
       // public virtual Users User { get; set; }
    }
}
