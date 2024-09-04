using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class BlockedUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string BlockerUserId { get; set; }

        [ForeignKey("BlockerUserId")]
        public User? Blocker { get; set; }

        [Required]
        public required string BlockedUserId { get; set; }

        [ForeignKey("BlockedUserId")]
        public User? Blocked { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}