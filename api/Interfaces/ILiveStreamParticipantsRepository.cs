using api.Models;

namespace api.Interfaces
{
    public interface ILiveStreamParticipantsRepository
    {
        Task<List<LiveStreamParticipant>> GetAllAsync();
    }
}