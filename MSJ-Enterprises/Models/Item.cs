using System.ComponentModel.DataAnnotations;

namespace MSJ_Enterprises.Models
{
    public class Item
    {
        [Key]
        public int Iid { get; set; }

        [Required]

        [Display(Name="Item Name")]
        public string Name { get; set; }


        [Required]

        public int Pack {  get; set; }
        
        [Required]
        [Display(Name = "Sale Rate")]
        public int Sale_Rate { get; set; }

        [Required]
        [Display(Name = "Purchase Rate")]
        public int Purchase_Rate { get; set; }



    }
}
