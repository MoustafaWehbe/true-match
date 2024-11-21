using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data
{
    public class AvailableDescriptorConfiguration : IEntityTypeConfiguration<AvailableDescriptor>
    {
        public void Configure(EntityTypeBuilder<AvailableDescriptor> builder)
        {
            builder.Property(ad => ad.Descriptors).HasColumnType("jsonb");
        }
    }
}
