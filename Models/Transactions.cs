using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomerceWebAPIs.Models
{
    public class Transactions
    {
        [Key]
        public int TransactionID { get; set; }

        [ForeignKey("Orders")]
        public int OrderID { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        [MaxLength(50)]
        public string TransactionStatus { get; set; }

        [Required]
        [MaxLength(50)]
        public string PaymentMethod { get; set; }

        [MaxLength(100)]
        public string TransactionReference { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // Navigation property
        public virtual Orders Order { get; set; }
    }
}
