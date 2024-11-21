using api.Models;

namespace api.Dtos
{
    public class MediaDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string? Url { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public MediaType MediaType { get; set; }

        public required string UserId { get; set; }
    }
}
