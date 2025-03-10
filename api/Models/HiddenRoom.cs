using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class HiddenRoom
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public required string UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        [Required]
        public required Guid RoomId { get; set; }

        [ForeignKey("RoomId")]
        public Room? Room { get; set; }

        public DateTime HiddenAt { get; set; } = DateTime.UtcNow;
    }
}
