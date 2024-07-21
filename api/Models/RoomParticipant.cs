using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("RoomParticipants")]
    public class RoomParticipant
    {
        [Key, Column(Order = 0)]
        public int RoomId { get; set; }

        [Key, Column(Order = 1)]
        public required string UserId { get; set; }
        public bool IsInterested { get; set; } = false;
        public bool Attended { get; set; } = false;
        public DateTime? AttendedFromTime { get; set; } = null;
        public DateTime? AttendedToTime { get; set; } = null;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("RoomId")]
        public Room? Room { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}