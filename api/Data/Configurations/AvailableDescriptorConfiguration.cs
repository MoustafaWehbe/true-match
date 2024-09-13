using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using api.Models;

namespace api.Data
{
    public class AvailableDescriptorConfiguration : IEntityTypeConfiguration<AvailableDescriptor>
    {
        public void Configure(EntityTypeBuilder<AvailableDescriptor> builder)
        {
            builder
             .Property(ad => ad.Descriptors)
             .HasColumnType("jsonb");
        }
    }
}
