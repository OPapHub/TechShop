using System.ComponentModel.DataAnnotations;

namespace ShopProject.Models
{
    public class Category
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<Product>? Products { get; set; }
    }
}
