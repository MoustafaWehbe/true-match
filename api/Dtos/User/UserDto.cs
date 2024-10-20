
using api.Models;

namespace api.Dtos
{
    public class UserDto
    {
        public required string Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public List<Media> Media { get; set; } = new List<Media>();
        public UserProfileDto? UserProfile { get; set; }
    }
}