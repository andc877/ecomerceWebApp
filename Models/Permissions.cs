using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomerceWebAPIs.Models
{
    public class Permissions
    {
        [Key]
        public int PermissionID { get; set; }

        [ForeignKey("Roles")]
        public int RoleID { get; set; }

        [Required]
        [MaxLength(50)]
        public string PermissionName { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation property
        public virtual Roles Role { get; set; }
    }
}
