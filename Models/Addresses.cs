using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomerceWebAPIs.Models
{
    public class Addresses
    {
        [Key]
        public int AddressID { get; set; }

        [Required]
        [ForeignKey("Users")]
        public int UserID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Street { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        public string State { get; set; }

        [Required]
        [MaxLength(100)]
        public string Country { get; set; }

        [Required]
        [MaxLength(20)]
        public string PostalCode { get; set; }

        public bool? IsDefault { get; set; }  // Assuming this is a flag to indicate if it's the default shipping/billing address

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation property
       // public virtual Users User { get; set; }
    }
}
