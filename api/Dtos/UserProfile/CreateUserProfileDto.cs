using System.ComponentModel.DataAnnotations;
using api.Models;

namespace api.Dtos
{
    public class CreateUserProfileDto
    {
        [Required(ErrorMessage = "Gender is required")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Nationality is required")]
        public string? Nationality { get; set; }

        [Required(ErrorMessage = "Place to live is required")]
        public string? PlaceToLive { get; set; }

        [Required(ErrorMessage = "Bio is required")]
        public string Bio { get; set; } = string.Empty;

        [Required(ErrorMessage = "Height is required")]
        [Range(0, 300.0, ErrorMessage = "Height must be between 0 and 3 meters")]
        public decimal Height { get; set; }

        [Required(ErrorMessage = "Relationship goal is required")]
        public string RelationshipGoal { get; set; } = string.Empty;

        [Required(ErrorMessage = "Education is required")]
        public string Education { get; set; } = string.Empty;

        [Required(ErrorMessage = "Zodiac is required")]
        public string Zodiac { get; set; } = string.Empty;

        [Required(ErrorMessage = "Love style is required")]
        public string LoveStyle { get; set; } = string.Empty;

        public List<UserProfileInterestDto> UserProfileInterests { get; set; } = new List<UserProfileInterestDto>();
        public List<UserProfileLifeStyleDto> UserProfileLifeStyles { get; set; } = new List<UserProfileLifeStyleDto>();
    }
}
