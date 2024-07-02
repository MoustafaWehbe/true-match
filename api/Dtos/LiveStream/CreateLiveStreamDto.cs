namespace api.Dtos.LiveStream
{
    public class CreateLiveStreamDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? ScheduledAt { get; set; }
    }
}
