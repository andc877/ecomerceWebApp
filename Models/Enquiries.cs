using System.ComponentModel.DataAnnotations;

namespace EcomerceWebAPIs.Models
{
    public class Enquiries
    {
        [Key]
        public int EnquiryID { get; set; }

        [Required]
        public string FullName { get; set; }

        public int MobileNo { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
