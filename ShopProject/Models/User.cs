using System.ComponentModel.DataAnnotations;

namespace ShopProject.Models
{
    public class User
    {
        [Required]
        public Guid Id { get; set; }
        [Required] 
        public string Username { get; set; } = string.Empty;
        [Required]
        public byte[] PasswordHash { get; set; } = new byte[0];
        [Required]
        public byte[] PasswordSalt { get; set; } = new byte[0];
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

    }
}
