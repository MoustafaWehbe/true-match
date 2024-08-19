using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace api.Models
{
    [Table("Rooms")]
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public RoomStatus Status { get; set; } = RoomStatus.Pending;
        public DateTime? ScheduledAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public JsonDocument? Offers { get; set; }
        public List<int> QuestionsCategories { get; set; } = new List<int>();

        [ForeignKey("UserId")]
        public required string UserId { get; set; }
        public User? User { get; set; }

        public ICollection<RoomParticipant> RoomParticipants { get; set; } = new List<RoomParticipant>();
    }
}