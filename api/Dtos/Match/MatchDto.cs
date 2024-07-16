using api.Models;

namespace api.Dtos.Match
{
    public class MatchDto
    {
        public int Id { get; set; }
        public User? User1 { get; set; }
        public User? User2 { get; set; }
        public MatchOrigin Origin { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}