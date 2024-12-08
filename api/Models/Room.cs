using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Table("Rooms")]
    [Index(nameof(StartedAt))]
    [Index(nameof(UserId))]
    [Index(nameof(CreatedAt))]
    [Index(nameof(FinishedAt))]
    [Index(nameof(IsDeleted))]
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? StartedAt { get; set; }
        public DateTime? ScheduledAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public JsonDocument? Offers { get; set; }
        public JsonDocument? RoomStateJson { get; set; }
        public List<Guid> QuestionsCategories { get; set; } = new List<Guid>();
        public bool IsDeleted { get; set; } = false;

        [ForeignKey("UserId")]
        public required string UserId { get; set; }
        public User? User { get; set; }

        public ICollection<RoomParticipant> RoomParticipants { get; set; } =
            new List<RoomParticipant>();

        // scheduled + 10mins > now > scheduled - 1min
        [NotMapped]
        public bool canStart =>
            ScheduledAt.HasValue
                ? DateTime.UtcNow.AddMinutes(-RoomConstants.TheRoomIsValidFor) <= ScheduledAt.Value
                    && DateTime.UtcNow >= ScheduledAt.Value.AddMinutes(-1)
                : false;

        [NotMapped]
        public bool IsExpired =>
            (
                StartedAt.HasValue
                && StartedAt.Value.AddMinutes(RoomConstants.TotalRoundsDuration + 1)
                    <= DateTime.UtcNow
            )
            || (
                !StartedAt.HasValue
                && ScheduledAt.HasValue
                && DateTime.UtcNow > ScheduledAt.Value.AddMinutes(RoomConstants.TheRoomIsValidFor)
            );

        [NotMapped]
        public RoomState? RoomState =>
            RoomStateJson != null
                ? JsonSerializer.Deserialize<RoomState>(RoomStateJson.RootElement.GetRawText())
                : null;

        public bool IsArchived()
        {
            return FinishedAt < DateTime.UtcNow || IsExpired;
        }

        public bool IsInProgress()
        {
            return !IsExpired && !FinishedAt.HasValue && StartedAt.HasValue;
        }
    }
}
