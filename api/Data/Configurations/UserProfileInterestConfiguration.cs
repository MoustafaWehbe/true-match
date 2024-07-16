using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using api.Models;

namespace api.Data
{
    public class UserProfileInterestConfiguration : IEntityTypeConfiguration<UserProfileInterest>
    {
        public void Configure(EntityTypeBuilder<UserProfileInterest> builder)
        {
            builder.HasKey(p => new { p.UserProfileId, p.InterestId });

            builder
                .HasOne(u => u.UserProfile)
                .WithMany(u => u.UserProfileInterests)
                .HasForeignKey(ui => ui.UserProfileId);

            builder
                .HasOne(u => u.Interest)
                .WithMany(u => u.UserProfileInterests)
                .HasForeignKey(ui => ui.InterestId);
        }
    }
}
