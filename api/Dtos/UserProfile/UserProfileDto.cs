namespace api.Dtos
{
    public class UserProfileDto
    {
        public int Id { get; set; }

        public string? Bio { get; set; }

        public decimal Height { get; set; }

        public string? RelationshipGoal { get; set; }

        public string? Education { get; set; }

        public string? Zodiac { get; set; }

        public string? LoveStyle { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public List<UserProfileInterestDto> UserProfileInterests { get; set; } = new List<UserProfileInterestDto>();
        public List<UserProfileLifeStyleDto> UserProfileLifeStyles { get; set; } = new List<UserProfileLifeStyleDto>();

    }
}