using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MSJ_Enterprises.Models
{
    public class PurchaseInvoice
    {
        [Key]
        [Display(Name = "Invoice #")]
        public int ID { get; set; }
        [Required]
        [Display(Name = "Party Name")]
        public int CustomerId { get; set; }

        [Required]
        public string Date { get; set; }

        public int Total { get; set; }

        public virtual Customers? Customers { get; set; }

        [JsonIgnore]
        public virtual List<PurchaseItem>? PurchaseItems { get; set; }


    }
}
