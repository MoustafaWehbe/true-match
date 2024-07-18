using api.Models;

namespace api.Dtos
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool HasStarted { get; set; } = false;
        public DateTime? ScheduledAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public UserSimplifiedDto? User { get; set; }
        public ICollection<RoomParticipant> RoomParticipants { get; set; } = new List<RoomParticipant>();
    }
}