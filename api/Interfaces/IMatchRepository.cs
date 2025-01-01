using api.Models;

namespace api.Interfaces
{
    public interface IMatchRepository
    {
        Task<Match> CreateAsync(Match match);
        Task<Match?> GetByIdAsync(Guid id);
        Task DeleteAsync(Match match);
        Task<List<Match>> GetMatchesForUserAsync(string userId);
    }
}
