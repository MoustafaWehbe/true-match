using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using api.Models;

namespace api.Data
{
    public class MatchConfiguration : IEntityTypeConfiguration<Match>
    {
        public void Configure(EntityTypeBuilder<Match> builder)
        {
            builder
               .HasOne(m => m.User1)
               .WithMany(u => u.MatchesAsUser1)
               .HasForeignKey(m => m.User1Id)
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(m => m.User2)
                .WithMany(u => u.MatchesAsUser2)
                .HasForeignKey(m => m.User2Id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
