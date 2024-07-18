using api.Models;

namespace api.Dtos
{
    public class LiveStreamDto
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
        public ICollection<LiveStreamParticipant> LiveStreamParticipants { get; set; } = new List<LiveStreamParticipant>();
    }
}