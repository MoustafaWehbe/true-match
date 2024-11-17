using api.Models;

namespace api.Dtos
{
    public class MatchDto
    {
        public Guid Id { get; set; }
        public UserSimplifiedDto? User1 { get; set; }
        public UserSimplifiedDto? User2 { get; set; }
        public MatchOrigin Origin { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}