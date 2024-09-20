using System.ComponentModel.DataAnnotations;

namespace MSJ_Enterprises.Models
{
    public class Login
    {
        [Key]
        public int uid { get; set; }

        [Required]

        public string Email { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Role { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
