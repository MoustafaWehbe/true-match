
using api.Models;

namespace api.Dtos
{
    public class UserDto
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public List<UserProfileInterest> UserProfileInterests { get; set; } = new List<UserProfileInterest>();
        public List<UserProfileLifeStyle> UserProfileLifeStyles { get; set; } = new List<UserProfileLifeStyle>();
        public List<LiveStream> LiveStreams { get; set; } = new List<LiveStream>();
        public List<Media> Media { get; set; } = new List<Media>();
        public UserProfile? UserProfile { get; set; }
    }
}