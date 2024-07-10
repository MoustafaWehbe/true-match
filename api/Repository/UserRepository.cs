using api.Data;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;
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
                .Include(u => u.LiveStreams)
                    .ThenInclude(ls => ls.LiveStreamParticipants)
                .Include(u => u.Media)
                .Include(u => u.UserProfile)
                .Include(u => u.UserProfile)
                    .ThenInclude(up => up.UserProfileInterests)
                .Include(u => u.UserProfile)
                    .ThenInclude(up => up.UserProfileLifeStyles)
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();
        }
        public async Task<int> GetTotalUsersAsync()
        {
            return await _context.Users.CountAsync();
        }

        public async Task<int> GetTotalPagesAsync(int pageSize)
        {
            if (pageSize <= 0)
            {
                throw new ArgumentException("Page size must be greater than zero.");
            }

            var totalUsers = await GetTotalUsersAsync();
            return (int)Math.Ceiling(totalUsers / (double)pageSize);
        }
    }
}