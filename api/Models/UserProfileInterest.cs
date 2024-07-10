using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("UserProfileInterests")]
    public class UserProfileInterest
    {
        public int UserProfileId { get; set; }
        public int InterestId { get; set; }
        public UserProfile UserProfile { get; set; }
        public Interest Interest { get; set; }
    }
}