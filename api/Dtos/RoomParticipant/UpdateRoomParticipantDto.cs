namespace api.Dtos
{
    public class UpdateRoomParticipantDto
    {
        public bool IsInterested { get; set; } = false;
        public DateTime? AttendedFromTime { get; set; } = null;
        public DateTime? AttendedToTime { get; set; } = null;
    }
}
