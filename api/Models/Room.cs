using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace api.Models
{
    [Table("Rooms")]
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

        public ICollection<RoomParticipant> RoomParticipants { get; set; } = new List<RoomParticipant>();

        // scheduled + 10mins > now > scheduled - 1min
        [NotMapped]
        public bool canStart => ScheduledAt.HasValue ?
            DateTime.UtcNow.AddMinutes(-RoomConstants.TheRoomIsValidFor) <= ScheduledAt.Value
                && DateTime.UtcNow >= ScheduledAt.Value.AddMinutes(-1) : false;

        // TODO: 1 should be the total time used by the user to pause the room
        // A maximum of 3 pauses, each lasting 15 seconds, is permitted per room.
        [NotMapped]
        public DateTime? expiresAt => StartedAt.HasValue ? StartedAt.Value.AddMinutes(RoomConstants.TotalRoundsDuration + 1) : null;

        [NotMapped]
        public bool isExpired => expiresAt != null && DateTime.UtcNow > expiresAt.Value;

        // We know that the room never started if the rounds itself has not started and we passed the first specified 10 mins
        [NotMapped]
        public bool neverStarted => RoomState != null && !RoomState.RoundStartTime.HasValue && ScheduledAt.HasValue &&
            DateTime.UtcNow > ScheduledAt.Value.AddMinutes(RoomConstants.TheRoomIsValidFor);

        [NotMapped]
        public RoomState? RoomState => RoomStateJson != null
            ? JsonSerializer.Deserialize<RoomState>(RoomStateJson.RootElement.GetRawText())
            : null;

        public bool IsArchived(string userId)
        {
            return FinishedAt < DateTime.UtcNow ||
            // room started but everyone left
            (
                RoomParticipants.Count != 0 &&
                !RoomParticipants
                .Where(rp => rp.UserId == userId && rp.RoomId == Id)
                .Any(rp => rp.RoomParticipantEvents
                    .Any(rpe => !rpe.Left))
            );
        }

        public bool IsInProgress(string userId)
        {
            return StartedAt != null && FinishedAt == null && RoomParticipants
                .Where(rp => rp.UserId == userId && rp.RoomId == Id)
                .Any(rp => rp.RoomParticipantEvents.Any(rpe => !rpe.Left));
        }

        // [NotMapped]
        // public DateTime? EndTime
        // {
        //     get
        //     {
        //         if (RoomStateDeserialized == null || !RoomStateDeserialized.RoundStartTime.HasValue)
        //         {
        //             return null;
        //         }
        //         else
        //         {
        //             return RoomStateDeserialized.RoundStartTime.Value.AddMinutes(RoomConstants.TotalRoundsDuration);
        //         }
        //     }
        // }
    }
}