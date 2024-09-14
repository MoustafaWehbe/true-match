using System.Text.Json;

namespace api.Dtos
{
    public class RoomDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public JsonDocument? Offers { get; set; }
        public List<int> QuestionsCategories { get; set; } = new List<int>();
        public DateTime? ScheduledAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public UserSimplifiedDto? User { get; set; }
        public int ParticipantCount { get; set; }
        public bool IsParticipanting { get; set; }
    }
}