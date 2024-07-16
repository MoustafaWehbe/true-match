using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("UserProfileLifeStyles")]
    public class UserProfileLifeStyle
    {
        public int UserProfileId { get; set; }
        public int LifeStyleId { get; set; }
        public UserProfile? UserProfile { get; set; }
        public LifeStyle? LifeStyle { get; set; }
    }
}