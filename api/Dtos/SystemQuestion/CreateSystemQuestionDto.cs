namespace api.DTOs
{
    public class CreateSystemQuestionDto
    {
        public required string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
