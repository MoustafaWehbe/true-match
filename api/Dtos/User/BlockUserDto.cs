using System.ComponentModel.DataAnnotations;

namespace api.Dtos
{
    public class BlockUserDto
    {
        [Required]
        public required string BlockedUserId { get; set; }
    }
}
