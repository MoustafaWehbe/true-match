using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using api.Models;

namespace api.Dtos
{
    public class CreateOrUpdateUserProfileDto
    {
        public string? PlaceToLive { get; set; }
        public string? Bio { get; set; }
        public string? LoveStyle { get; set; }
        public int? AgeFilterMax { get; set; }
        public int? AgeFilterMin { get; set; }
        public int? DistanceFilter { get; set; }
        public string? pos { get; set; }
        public JsonDocument? Location { get; set; }
        public string? Job { get; set; }
        public string? School { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? UserId { get; set; }
        public JsonDocument? SelectedDescriptors { get; set; }
        public List<UserProfileGenderDto>? UserProfileGenders { get; set; }
    }
}
