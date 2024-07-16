using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly ApplicationDBContext _context;
        public UserProfileRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<UserProfile> CreateAsync(UserProfile userProfile)
        {
            _context.UserProfiles.Add(userProfile);
            await _context.SaveChangesAsync();
            return userProfile;
        }

        public async Task<UserProfile?> GetByIdAsync(int id)
        {
            return await _context.UserProfiles.Include(a => a.User).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}