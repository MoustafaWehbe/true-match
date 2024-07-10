using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }

        public string Bio { get; set; }

        [Column(TypeName = "decimal(3, 2)")]
        public decimal Height { get; set; }

        public string RelationshipGoal { get; set; }

        public string Education { get; set; }

        public string Zodiac { get; set; }

        public string LoveStyle { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public List<UserProfileInterest> UserProfileInterests { get; set; } = new List<UserProfileInterest>();
        public List<UserProfileLifeStyle> UserProfileLifeStyles { get; set; } = new List<UserProfileLifeStyle>();

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
