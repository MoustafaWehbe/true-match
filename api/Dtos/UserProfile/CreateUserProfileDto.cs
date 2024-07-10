using api.Models;

namespace api.Dtos.UserProfile
{
    public class CreateUserProfileDto
    {
        public string Bio { get; set; } = string.Empty;
        public decimal Height { get; set; }
        public string RelationshipGoal { get; set; } = string.Empty;
        public string Education { get; set; } = string.Empty;
        public string Zodiac { get; set; } = string.Empty;
        public string LoveStyle { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public List<UserProfileInterest> UserProfileInterests { get; set; } = new List<UserProfileInterest>();
        public List<UserProfileLifeStyle> UserProfileLifeStyles { get; set; } = new List<UserProfileLifeStyle>();
    }
}
