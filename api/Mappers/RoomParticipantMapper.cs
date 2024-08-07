using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class RoomParticipantMapper
    {
        public static RoomParticipantDto ToRoomParticipantDto(this RoomParticipant roomParticipantModel)
        {
            return new RoomParticipantDto
            {
                IsInterested = roomParticipantModel.IsInterested,
                Attended = roomParticipantModel.Attended,
                AttendedFromTime = roomParticipantModel.AttendedFromTime,
                AttendedToTime = roomParticipantModel.AttendedToTime,
                RoomId = roomParticipantModel.RoomId,
                UserId = roomParticipantModel.UserId,
                SocketId = roomParticipantModel.SocketId
            };
        }

        public static RoomParticipant ToRoomParticipantFromUpdate(this UpdateRoomParticipantDto roomParticipantDto, string userId, int roomId)
        {
            return new RoomParticipant
            {
                UserId = userId,
                RoomId = roomId,
                IsInterested = roomParticipantDto.IsInterested,
                AttendedFromTime = roomParticipantDto.AttendedFromTime,
                AttendedToTime = roomParticipantDto.AttendedToTime
            };
        }
    }
}