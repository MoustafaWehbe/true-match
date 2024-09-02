using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using api.Models;

namespace api.Data
{
    public class RoomParticipantEventConfiguration : IEntityTypeConfiguration<RoomParticipantEvent>
    {
        public void Configure(EntityTypeBuilder<RoomParticipantEvent> builder)
        {
            builder
                .HasOne(lsp => lsp.RoomParticipant)
                .WithMany(ls => ls.RoomParticipantEvents)
                .HasForeignKey(lsp => lsp.RoomParticipantId);
        }
    }
}
