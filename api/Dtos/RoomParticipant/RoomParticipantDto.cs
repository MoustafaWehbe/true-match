namespace api.Dtos
{
    public class RoomParticipantDto
    {
        public bool IsInterested { get; set; } = false;
        public bool Attended { get; set; } = false;
        public DateTime? AttendedFromTime { get; set; } = null;
        public DateTime? AttendedToTime { get; set; } = null;
        public required int RoomId { get; set; }
        public string SocketId { get; set; } = string.Empty;
        public required string UserId { get; set; }
    }
}