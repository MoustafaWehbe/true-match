using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("UserInterests")]
    public class UserInterest
    {
        public string UserId { get; set; }
        public int InterestId { get; set; }
        public User User { get; set; }
        public Interest Interest { get; set; }
    }
}