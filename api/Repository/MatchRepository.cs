using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class MatchRepository : IMatchRepository
    {
        private readonly ApplicationDBContext _context;

        public MatchRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Match> CreateAsync(Match match)
        {
            var user2 = await _context.Users.FindAsync(match.User2Id);

            if (user2 == null)
            {
                throw new InvalidDataException("user not found.");
            }

            var isAlreadyMatch = await _context.Matches.FirstOrDefaultAsync(m =>
                (m.User1Id == match.User1Id && m.User2Id == match.User2Id)
                || (m.User1Id == match.User2Id && m.User2Id == match.User1Id)
            );

            if (isAlreadyMatch != null)
            {
                throw new InvalidDataException("User is already a match.");
            }

            _context.Matches.Add(match);
            await _context.SaveChangesAsync();
            return match;
        }

        public async Task<Match?> GetByIdAsync(Guid id)
        {
            return await _context
                .Matches.Include(m => m.User1)
                .Include(m => m.User2)
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<Match>> GetMatchesForUserAsync(string userId)
        {
            return await _context
                .Matches.Include(m => m.User1)
                .Include(m => m.User2)
                .Where(m => m.User1Id == userId || m.User2Id == userId)
                .ToListAsync();
        }
    }
}
