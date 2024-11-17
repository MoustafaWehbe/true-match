namespace api.Dtos
{
    public class RoomParticipantDto
    {
        public required Guid RoomId { get; set; }
        public required string UserId { get; set; }
    }
}