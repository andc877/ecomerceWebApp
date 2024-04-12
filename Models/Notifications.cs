using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomerceWebAPIs.Models
{
    public class Notifications
    {
        [Key]
        public int NotificationID { get; set; }

        [ForeignKey("Users")]
        public int UserID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Subject { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime DateSent { get; set; } = DateTime.Now;

        public bool IsRead { get; set; }

        // Navigation property
        public virtual Users User { get; set; }
    }
}
