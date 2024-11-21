using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Gender
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public string? Description { get; set; }
        public Guid? ParentId { get; set; }

        // Navigation property for parent gender
        [ForeignKey("ParentId")]
        public Gender? Parent { get; set; }

        // Navigation property for child genders
        public ICollection<Gender>? Children { get; set; }

        public List<UserProfileGender> UserProfileGenders { get; set; } =
            new List<UserProfileGender>();
    }
}
