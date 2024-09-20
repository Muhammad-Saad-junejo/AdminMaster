using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MSJ_Enterprises.Models
{
    public class SaleItem
    {
        [Key]
        public int ID { get; set; }
        [Display(Name ="Item Name")]
        public int ItemID { get; set; }
        [Required]
        public int Qty { get; set; }

        [Required]
        public int Rate { get; set; }


        [Required]
        public int Discount { get; set; }

        [Required]
        public int Amount { get; set; }
        [JsonIgnore]
        public virtual Item? Item { get; set; }


        [JsonIgnore]
        public virtual SaleInvoice? SaleInvoice { get; set; }
    }
}
