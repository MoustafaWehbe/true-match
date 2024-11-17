using System.Text.Json;
using api.Models;

namespace api.Dtos
{
    public class RoomDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public JsonDocument? Offers { get; set; }
        public RoomState? RoomState { get; set; }
        public List<Guid> QuestionsCategories { get; set; } = new List<Guid>();
        public DateTime? ScheduledAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public UserSimplifiedDto? User { get; set; }
        public int ParticipantCount { get; set; }
        public bool IsParticipanting { get; set; }
    }
}