namespace api.Dtos
{
    public class CreateRoomDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? ScheduledAt { get; set; }
    }
}