using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopProject.Models
{
    public class Product
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Required]
        public double Price { get; set; }
        [Required]
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
