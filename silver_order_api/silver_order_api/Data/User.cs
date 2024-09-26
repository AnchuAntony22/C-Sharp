using System.ComponentModel.DataAnnotations;

namespace silver_order_api.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; } // Store the hashed password
        public string Role { get; set; }
    }
}
