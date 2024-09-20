using System.ComponentModel.DataAnnotations;

namespace MSJ_Enterprises.Models
{
    public class Bank
    {
        [Key]
        public int Tid { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]

        [Display(Name ="Party Name")]
        public int CustomerId { get; set; }

        [Display(Name = "Payment Type")]
        [Required]
        public string PaymentType { get; set; }

        [Display(Name ="Cheque No")]
        [Required]
        public string ChqNo { get; set; }

        [Required]
        public string Description { get; set; }
        
        [Required]
        public int Debit { get; set; }

        [Required]
        public int Credit { get; set; }

        public virtual Customers? Customers { get; set; }


    }
}
