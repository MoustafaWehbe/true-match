namespace api.Dtos
{
    public class UpdateRoomDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? ScheduledAt { get; set; }
        public bool HasStarted { get; set; } = false;
        public DateTime? FinishedAt { get; set; }
    }
}
