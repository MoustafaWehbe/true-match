using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using api.Models;

namespace api.Data
{
    public class UserProfileLifeStyleConfiguration : IEntityTypeConfiguration<UserProfileLifeStyle>
    {
        public void Configure(EntityTypeBuilder<UserProfileLifeStyle> builder)
        {
            builder.HasKey(p => new { p.UserProfileId, p.LifeStyleId });

            builder
                .HasOne(u => u.UserProfile)
                .WithMany(u => u.UserProfileLifeStyles)
                .HasForeignKey(ui => ui.UserProfileId);

            builder
                .HasOne(u => u.LifeStyle)
                .WithMany(u => u.userProfileLifeStyles)
                .HasForeignKey(ui => ui.LifeStyleId);
        }
    }
}
