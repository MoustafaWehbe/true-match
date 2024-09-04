namespace api.Dtos
{
    public class RoomParticipantDto
    {
        public required int RoomId { get; set; }
        public required string UserId { get; set; }
    }
}