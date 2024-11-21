using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data
{
    public class UserProfileGenderConfiguration : IEntityTypeConfiguration<UserProfileGender>
    {
        public void Configure(EntityTypeBuilder<UserProfileGender> builder)
        {
            builder.HasKey(p => new { p.UserProfileId, p.GenderId });

            builder
                .HasOne(u => u.UserProfile)
                .WithMany(u => u.UserProfileGenders)
                .HasForeignKey(ui => ui.UserProfileId);

            builder
                .HasOne(u => u.Gender)
                .WithMany(u => u.UserProfileGenders)
                .HasForeignKey(ui => ui.GenderId);
        }
    }
}
