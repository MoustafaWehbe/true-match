using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("UserProfileGenders")]
    public class UserProfileGender
    {
        [Key, Column(Order = 1)]
        [ForeignKey("UserProfile")]
        public int UserProfileId { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey("Gender")]
        public int GenderId { get; set; }
        public bool? isMain { get; set; }
        public UserProfile? UserProfile { get; set; }
        public Gender? Gender { get; set; }
    }
}