
namespace api.Dtos.User
{
    public class UserDto
    {
        public string? UserName { get; set; }
        public List<Models.UserProfileInterest> UserProfileInterests { get; set; } = new List<Models.UserProfileInterest>();
        public List<Models.UserProfileLifeStyle> UserProfileLifeStyles { get; set; } = new List<Models.UserProfileLifeStyle>();
        public List<Models.LiveStream> LiveStreams { get; set; } = new List<Models.LiveStream>();
        public List<Models.Media> Media { get; set; } = new List<Models.Media>();
        public Models.UserProfile UserProfile { get; set; }
    }
}