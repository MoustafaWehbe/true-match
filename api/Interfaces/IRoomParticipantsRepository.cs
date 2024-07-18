using api.Models;

namespace api.Interfaces
{
    public interface IRoomParticipantsRepository
    {
        Task<List<RoomParticipant>> GetAllAsync();
    }
}