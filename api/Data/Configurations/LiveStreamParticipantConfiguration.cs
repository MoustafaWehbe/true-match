using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using api.Models;

namespace api.Data
{
    public class LiveStreamParticipantConfiguration : IEntityTypeConfiguration<LiveStreamParticipant>
    {
        public void Configure(EntityTypeBuilder<LiveStreamParticipant> builder)
        {
            builder.HasKey(lsp => new { lsp.LiveStreamId, lsp.UserId });

            builder
                .HasOne(lsp => lsp.LiveStream)
                .WithMany(ls => ls.LiveStreamParticipants)
                .HasForeignKey(lsp => lsp.LiveStreamId);

            builder
                .HasOne(lsp => lsp.User)
                .WithMany(u => u.LiveStreamParticipants)
                .HasForeignKey(lsp => lsp.UserId);
        }
    }
}
