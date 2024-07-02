
namespace api.Dtos.User
{
    public class UserDto
    {
        public string? UserName { get; set; }
        public List<Models.UserInterest> UserInterests { get; set; } = new List<Models.UserInterest>();
        public List<Models.UserLifeStyle> UserLifeStyles { get; set; } = new List<Models.UserLifeStyle>();
        public List<Models.LiveStream> LiveStreams { get; set; } = new List<Models.LiveStream>();
        public List<Models.Media> Media { get; set; } = new List<Models.Media>();
        public Models.UserProfile UserProfile { get; set; }
    }
}