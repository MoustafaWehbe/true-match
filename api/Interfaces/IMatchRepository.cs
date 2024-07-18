using api.Models;

namespace api.Interfaces
{
    public interface IMatchRepository
    {
        Task<Match> CreateAsync(Match match);
        Task<Match?> GetByIdAsync(int id);
        Task<List<Match>> GetMatchesForUserAsync(string userId);
    }
}