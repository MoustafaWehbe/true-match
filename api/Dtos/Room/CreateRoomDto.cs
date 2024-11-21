namespace api.Dtos
{
    public class CreateRoomDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<Guid> QuestionsCategories { get; set; } = new List<Guid>();
        public DateTime? ScheduledAt { get; set; }
    }
}
