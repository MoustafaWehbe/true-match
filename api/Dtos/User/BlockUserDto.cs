using System.ComponentModel.DataAnnotations;

public class BlockUserDto
{
    [Required]
    public required string BlockedUserId { get; set; }
}
