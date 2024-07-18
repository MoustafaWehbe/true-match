namespace api.Dtos
{
    public class RoomParticipantDto
    {
        public bool IsInterested { get; set; } = false;
        public bool Attended { get; set; } = false;
        public DateTime? AttendedFromTime { get; set; } = null;
        public DateTime? AttendedToTime { get; set; } = null;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}