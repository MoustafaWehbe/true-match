using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.Data
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasAnnotation("Npgsql:Enum:message_status", "Sent,Delivered,Read");

            builder.Property(m => m.Status).HasConversion<string>();

            // builder
            //     .Property(m => m.Status)
            //     .HasConversion<string>()
            //     .HasColumnType("message_status");
        }
    }
}
