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
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? StartedAt { get; set; }
        public DateTime? ScheduledAt { get; set; }
        public DateTime? FinishedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public JsonDocument? Offers { get; set; }
        public JsonDocument? RoomStateJson { get; set; }
        public List<int> QuestionsCategories { get; set; } = new List<int>();
        public bool IsDeleted { get; set; } = false;

        [ForeignKey("UserId")]
        public required string UserId { get; set; }
        public User? User { get; set; }

        public ICollection<RoomParticipant> RoomParticipants { get; set; } = new List<RoomParticipant>();

        // The room will be valid for 10 mins after the scheduled time. If you don't start it within those 10 mins,
        // you won't be able to start it anymore
        [NotMapped]
        public bool canStart => ScheduledAt.HasValue ?
            DateTime.UtcNow.AddMinutes(-RoomConstants.TheRoomIsValidFor) <= ScheduledAt : false;

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