
namespace api.Dtos
{
    public class UserDto
    {
        public required string Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public List<MediaDto> Media { get; set; } = new List<MediaDto>();
        public UserProfileDto? UserProfile { get; set; }
    }
}