using api.Models;

namespace api.Interfaces
{
    public interface IMatchRepository
    {
        Task<Match> CreateAsync(Match match);
        Task<Match?> GetByIdAsync(Guid id);
        Task<List<Match>> GetMatchesForUserAsync(string userId);
    }
}