namespace api.Dtos
{
    public class CreateRoomParticipantDto
    {
        public required int RoomId { get; set; }
        public required string SocketId { get; set; }
    }
}