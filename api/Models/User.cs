using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace api.Models
{
    public class User : IdentityUser
    {
        [Column(TypeName = "VARCHAR(50)")]
        public required string FirstName { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public required string LastName { get; set; }

        public List<LiveStream> LiveStreams { get; set; } = new List<LiveStream>();
        public List<LiveStreamParticipant> LiveStreamParticipants { get; set; } = new List<LiveStreamParticipant>();
        public List<Media> Media { get; set; } = new List<Media>();
        public UserProfile? UserProfile { get; set; }
        public List<Match> MatchesAsUser1 { get; set; } = new List<Match>();
        public List<Match> MatchesAsUser2 { get; set; } = new List<Match>();
    }
}

