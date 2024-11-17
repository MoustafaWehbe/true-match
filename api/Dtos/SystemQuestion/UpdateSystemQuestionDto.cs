namespace api.Dtos
{
    public class UpdateSystemQuestionDto
    {
        public required string Name { get; set; }
        public Guid CategoryId { get; set; }
    }
}
