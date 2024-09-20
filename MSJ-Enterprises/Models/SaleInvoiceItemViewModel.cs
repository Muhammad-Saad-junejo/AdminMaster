namespace MSJ_Enterprises.Models
{
    public class SaleInvoiceItemViewModel
    {
        public int ItemId { get; set; }
        
        public int Quantity { get; set; }
        public int Rate { get; set; }

        public int Discount { get; set; }
        public int Amount { get; set; }
    }
}
