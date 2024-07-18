using api.Models;

namespace api.Interfaces
{
    public interface IRoomContentRepository
    {
        Task<List<RoomContent>> GetAllAsync();
    }
}