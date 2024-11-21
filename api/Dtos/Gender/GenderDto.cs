namespace api.Dtos
{
    public class GenderDto
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public Guid? ParentId { get; set; }
        public ICollection<GenderDto>? Children { get; set; }
    }
}
