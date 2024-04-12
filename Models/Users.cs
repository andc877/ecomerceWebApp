using System.ComponentModel.DataAnnotations;

namespace EcomerceWebAPIs.Models
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        [MaxLength(20)]
        public string MobileNUmber { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;  // Automatic setting of CreatedDate to current date and time

        // Foreign Key Relationships
        // If you want to add a foreign key to another table, you need to define a property for the related table's primary key and use the ForeignKey attribute
        // For example, if you have a table named Orders and you want to have a foreign key relationship with Users table
        // public int OrderID { get; set; }
        // [ForeignKey("OrderID")]
        // public virtual Orders Order { get; set; }

    }
}
