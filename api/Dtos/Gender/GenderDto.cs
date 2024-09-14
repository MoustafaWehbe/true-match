namespace api.Dtos
{
    public class GenderDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int? ParentId { get; set; }
        public ICollection<GenderDto>? Children { get; set; }
    }

}