using api.Dtos;
using api.Models;

namespace api.Interfaces
{
    public interface IRoomParticipantsRepository
    {
        Task<List<RoomParticipant>> GetRoomParticipantsAsync(User user);
        Task<RoomParticipant?> CreateAsync(RoomParticipant roomParticipant);
        Task<RoomParticipantEvent?> CreateRoomParticipantEventAsync(RoomParticipantEvent roomParticipantEvent);
        Task DeleteAsync(int roomId, string userId);
    }
}