namespace api.Dtos
{
    public class CreateSystemQuestionDto
    {
        public required string Name { get; set; }
        public Guid CategoryId { get; set; }
    }
}
