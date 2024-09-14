using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace api.Models
{
    public class UserProfile
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public string? Bio { get; set; }
        public int? AgeFilterMax { get; set; }
        public int? AgeFilterMin { get; set; }
        public int? DistanceFilter { get; set; }

        // pos = $"({longitude}, {latitude})"
        // exact location: you obtain it after user enables location
        public string? pos { get; set; }
        // {
        //     coords: {lat, long}, 
        //     name: Beirut, 
        //     region: Lebanon
        // }
        // obtained from autocomplete resources like Mapbox...
        public JsonDocument? Location { get; set; }
        public string? Job { get; set; }
        public string? School { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        public JsonDocument? SelectedDescriptors { get; set; }
        public List<UserProfileGender> UserProfileGenders { get; set; } = new List<UserProfileGender>();
    }
}
