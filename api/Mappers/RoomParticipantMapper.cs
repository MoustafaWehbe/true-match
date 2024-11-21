using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class RoomParticipantMapper
    {
        public static RoomParticipantDto ToRoomParticipantDto(
            this RoomParticipant roomParticipantModel
        )
        {
            return new RoomParticipantDto
            {
                RoomId = roomParticipantModel.RoomId,
                UserId = roomParticipantModel.UserId,
            };
        }
    }
}
