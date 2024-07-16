using System.ComponentModel.DataAnnotations;

namespace api.Dtos
{
    public class RegisterDto
    {
        [Required]
        public required string FirstName { get; set; }
        public required string LastName { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}