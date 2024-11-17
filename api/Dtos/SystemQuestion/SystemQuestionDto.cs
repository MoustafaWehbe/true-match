namespace api.Dtos
{
    public class SystemQuestionDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public Guid CategoryId { get; set; }
    }
}
