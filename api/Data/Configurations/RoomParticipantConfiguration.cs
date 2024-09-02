using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using api.Models;

namespace api.Data
{
    public class RoomParticipantConfiguration : IEntityTypeConfiguration<RoomParticipant>
    {
        public void Configure(EntityTypeBuilder<RoomParticipant> builder)
        {
            builder.HasKey(lsp => new { lsp.Id });

            builder
                .HasOne(lsp => lsp.Room)
                .WithMany(ls => ls.RoomParticipants)
                .HasForeignKey(lsp => lsp.RoomId);

            builder
                .HasOne(lsp => lsp.User)
                .WithMany(u => u.RoomParticipants)
                .HasForeignKey(lsp => lsp.UserId);
        }
    }
}
