using api.Dtos;
using api.Models;

namespace api.Interfaces
{
    public interface ILiveStreamRepository
    {
        Task<List<LiveStream>> GetAllAsync();
        Task<LiveStream> CreateAsync(LiveStream liveStream);
        Task<LiveStream?> GetByIdAsync(int id);
        Task<LiveStream?> UpdateAsync(int id, UpdateLiveStreamDto stockDto);
    }
}