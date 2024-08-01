using System.Text.Json;
using api.Models;

namespace api.Dtos
{
    public class UpdateRoomDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public JsonDocument? Offers { get; set; }
        public DateTime? ScheduledAt { get; set; }
        public RoomStatus Status { get; set; } = RoomStatus.Pending;
        public DateTime? FinishedAt { get; set; }
    }
}
