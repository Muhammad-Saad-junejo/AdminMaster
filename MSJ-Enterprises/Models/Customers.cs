using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MSJ_Enterprises.Models
{
    public class Customers
    {
        [Key]
        public int Cid { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]

        public string Address { get; set; }

        [Required]

        public string Opening_Date { get; set; }

        [JsonIgnore]
        public virtual List<Bank>? Bank { get; set; }

    }
}
