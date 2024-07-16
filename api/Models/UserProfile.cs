using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }

        public Gender Gender { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public string? Nationality { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public string? PlaceToLive { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public string? Bio { get; set; }

        [Column(TypeName = "decimal(3, 2)")]
        public decimal Height { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string? RelationshipGoal { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string? Education { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string? Zodiac { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string? LoveStyle { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public List<UserProfileInterest> UserProfileInterests { get; set; } = new List<UserProfileInterest>();
        public List<UserProfileLifeStyle> UserProfileLifeStyles { get; set; } = new List<UserProfileLifeStyle>();

        public required string UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
