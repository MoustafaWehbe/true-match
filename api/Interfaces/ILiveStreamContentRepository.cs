using api.Models;

namespace api.Interfaces
{
    public interface ILiveStreamContentRepository
    {
        Task<List<LiveStreamContent>> GetAllAsync();
    }
}