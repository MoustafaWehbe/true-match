using api.Models;

namespace api.Interfaces
{
    public interface ILiveStreamRepository
    {
        Task<List<LiveStream>> GetAllAsync();
        Task<LiveStream> CreateAsync(LiveStream liveStream);
        Task<LiveStream?> GetByIdAsync(int id);
    }
}