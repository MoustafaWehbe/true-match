using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace api.Models
{
    [Table("Matches")]
    public class Match
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public required string User1Id { get; set; }
        public User? User1 { get; set; }

        public required string User2Id { get; set; }
        public User? User2 { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public MatchOrigin Origin { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}