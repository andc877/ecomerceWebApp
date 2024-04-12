using System.ComponentModel.DataAnnotations;

namespace EcomerceWebAPIs.Models
{
    public class Roles
    {
        [Key]
        public int RoleID { get; set; }

        [Required]
        [MaxLength(50)]
        public string RoleName { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
