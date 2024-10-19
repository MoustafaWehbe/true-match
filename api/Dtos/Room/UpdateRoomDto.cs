using System.Text.Json;
using api.Models;

namespace api.Dtos
{
    public class UpdateRoomDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public JsonDocument? Offers { get; set; }
        public RoomState? RoomState { get; set; }
        public List<int>? QuestionsCategories { get; set; }
        public DateTime? ScheduledAt { get; set; }
        public DateTime? FinishedAt { get; set; }
    }
}
