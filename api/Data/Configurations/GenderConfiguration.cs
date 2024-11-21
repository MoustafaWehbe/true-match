using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder
                .HasMany(g => g.Children)
                .WithOne(g => g.Parent)
                .HasForeignKey(g => g.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
