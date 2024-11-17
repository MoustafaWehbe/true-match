using System.Text.Json;
using api.Models;
using NetTopologySuite.Geometries;

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
        public bool? Hidden { get; set; }
        public Point? pos { get; set; }
        public UserLocation? Location { get; set; }
        public string? Job { get; set; }
        public string? School { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? UserId { get; set; }
        public List<SelectedDescriptor>? SelectedDescriptors { get; set; }
        public List<UserProfileGenderDto>? UserProfileGenders { get; set; }
    }
}
