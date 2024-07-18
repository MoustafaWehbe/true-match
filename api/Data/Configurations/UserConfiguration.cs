using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using api.Models;

namespace api.Data
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
            .HasMany(u => u.Rooms)
            .WithOne(l => l.User)
            .HasForeignKey(l => l.UserId);

            builder
            .HasOne(u => u.UserProfile)
            .WithOne(up => up.User)
            .HasForeignKey<UserProfile>(up => up.UserId);

            builder
            .HasMany(u => u.Media)
            .WithOne(m => m.User)
            .HasForeignKey(m => m.UserId);
        }
    }
}
