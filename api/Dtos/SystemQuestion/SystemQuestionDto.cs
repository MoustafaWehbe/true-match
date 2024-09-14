namespace api.Dtos
{
    public class SystemQuestionDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int CategoryId { get; set; }
    }
}
