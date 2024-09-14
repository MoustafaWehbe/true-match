using System.Text.Json;

namespace api.Dtos
{
    public class UpdateRoomDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public JsonDocument? Offers { get; set; }
        public List<int> QuestionsCategories { get; set; } = new List<int>();
        public DateTime? ScheduledAt { get; set; }
        public DateTime? FinishedAt { get; set; }
    }
}
