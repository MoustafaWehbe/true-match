using api.Data;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync(UserQueryObject query)
        {
            if (query.PageNumber <= 0 || query.PageSize <= 0)
            {
                throw new ArgumentException("Page number and page size must be greater than zero.");
            }

            return await _context.Users
                .Include(u => u.Rooms)
                    .ThenInclude(ls => ls.RoomParticipants)
                .Include(u => u.Media)
                .Include(u => u.UserProfile)
                .Include(u => u.UserProfile)
                    .ThenInclude(up => up!.UserProfileInterests)
                .Include(u => u.UserProfile)
                    .ThenInclude(up => up!.UserProfileLifeStyles)
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();
        }
        public async Task<int> GetTotalUsersAsync()
        {
            return await _context.Users.CountAsync();
        }

        public int GetTotalPages(int pageSize, int totalUsers)
        {
            if (pageSize <= 0)
            {
                throw new ArgumentException("Page size must be greater than zero.");
            }

            return (int)Math.Ceiling(totalUsers / (double)pageSize);
        }

        public async Task<User?> GetByIdAsync(string userId)
        {
            return await _context.Users
                .Include(u => u.Media)
                .Include(u => u.UserProfile)
                .Include(u => u.UserProfile)
                    .ThenInclude(up => up!.UserProfileInterests)
                .Include(u => u.UserProfile)
                    .ThenInclude(up => up!.UserProfileLifeStyles)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}