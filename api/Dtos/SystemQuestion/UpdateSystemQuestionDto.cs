namespace api.DTOs
{
    public class UpdateSystemQuestionDto
    {
        public required string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
