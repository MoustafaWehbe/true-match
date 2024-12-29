using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("RoomParticipants")]
    public class RoomParticipant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public required Guid RoomId { get; set; }
        public required string UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("RoomId")]
        public Room? Room { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
        public DateTime? NotifiedAt { get; set; }

        public ICollection<RoomParticipantEvent> RoomParticipantEvents { get; set; } =
            new List<RoomParticipantEvent>();
    }
}
