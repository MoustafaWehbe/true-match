using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class User : IdentityUser
    {
        public List<UserInterest> UserInterests { get; set; } = new List<UserInterest>();
        public List<UserLifeStyle> UserLifeStyles { get; set; } = new List<UserLifeStyle>();
        public List<LiveStream> LiveStreams { get; set; } = new List<LiveStream>();
        public List<LiveStreamParticipant> LiveStreamParticipants { get; set; } = new List<LiveStreamParticipant>();
        public List<Media> Media { get; set; } = new List<Media>();

        public UserProfile UserProfile { get; set; }
    }
}

