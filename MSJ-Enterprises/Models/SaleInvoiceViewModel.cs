using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MSJ_Enterprises.Models
{
    public class SaleInvoiceViewModel
    {
      
        public int CustomerId { get; set; }
        [Key]
        public int Invoice { get; set; }
        public string Date { get; set; }

        public int Total { get; set; }

        [JsonIgnore]
        public virtual List<SaleInvoiceItemViewModel> SaleInvoiceItems { get; set; }
    }
}
