using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("UserLifeStyles")]
    public class UserLifeStyle
    {
        public string UserId { get; set; }
        public int LifeStyleId { get; set; }
        public User User { get; set; }
        public LifeStyle LifeStyle { get; set; }
    }
}