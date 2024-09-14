namespace api.Dtos
{
    public class CreateRoomDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<int> QuestionsCategories { get; set; } = new List<int>();
        public DateTime? ScheduledAt { get; set; }
    }
}
