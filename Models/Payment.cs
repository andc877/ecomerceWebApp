using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EcomerceWebAPIs.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [ForeignKey("Orders")]
        public int OrderID { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        public decimal PaymentAmount { get; set; }

        [Required]
        [MaxLength(100)]
        public string PaymentMethod { get; set; }

        // Optional foreign key if you want to track transaction
        // [ForeignKey("Transactions")]
        // public int TransactionID { get; set; }

        // Navigation property
        public virtual Orders Order { get; set; }
        // public virtual Transactions Transaction { get; set; }  // If you have a Transaction table

    }
}
