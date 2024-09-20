using System.ComponentModel.DataAnnotations;

namespace MSJ_Enterprises.Models
{
    public class PurchaseItem
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Item Name")]
        public int ItemID { get; set; }
        [Required]
        public int Qty { get; set; }

        [Required]
        public int Rate { get; set; }


        [Required]
        public int Discount { get; set; }

        [Required]
        public int Amount { get; set; }

        public virtual Item? Item { get; set; }

        public virtual PurchaseInvoice? PurchaseInvoice { get; set; }
    }
}
