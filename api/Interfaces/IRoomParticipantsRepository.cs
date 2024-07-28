using api.Dtos;
using api.Models;

namespace api.Interfaces
{
    public interface IRoomParticipantsRepository
    {
        Task<List<RoomParticipant>> GetRoomParticipantsAsync(User user);
        Task<RoomParticipant?> joinRoomAsync(User user, int roomId);
        Task<RoomParticipant?> UpdateRoomParticipantAsync(RoomParticipant existingRoomParticipant, UpdateRoomParticipantDto updateDto);
    }
}