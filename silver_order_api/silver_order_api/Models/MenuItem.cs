using System.ComponentModel.DataAnnotations;

namespace silver_order_api.Models
{
    public class MenuItem
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Price { get; set; }

        
        public byte[]? Image { get; set; }
        public string ImageType { get; set; } // New property to store the image type
    }
}

