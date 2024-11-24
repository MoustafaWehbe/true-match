using System.Linq;
using api.Data;
using api.Dtos;
using api.Expressions;
using api.Extensions;
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

        public async Task<List<User>> GetAllAsync(UserQueryObject query, UserProfile userProfile)
        {
            if (query.PageNumber <= 0 || query.PageSize <= 0)
            {
                throw new ArgumentException("Page number and page size must be greater than zero.");
            }

            if (userProfile.UserProfileGenderPreferences == null)
            {
                throw new Exception("User does not have a profile yet or it is not complete");
            }
            var preferencesFilter = PreferencesFilter.MatchesPreferencesFilter(userProfile);
            var userPreferencesFilter = preferencesFilter.Compose<User, UserProfile>(user =>
                user.UserProfile!
            );

            return await _context
                .Users.Include(u => u.Rooms)
                .ThenInclude(ls => ls.RoomParticipants)
                .Include(u => u.Media)
                .Include(u => u.UserProfile)
                .ThenInclude(up => up != null ? up.UserProfileGenders : null)
                .Where(u => u.Id != userProfile.UserId)
                .Where(userPreferencesFilter)
                .Skip((query.PageNumber - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();
        }

        public async Task<int> GetTotalUsersAsync(UserProfile userProfile)
        {
            if (userProfile.UserProfileGenderPreferences == null)
            {
                throw new Exception("User does not have a profile yet or it is not complete");
            }

            var preferencesFilter = PreferencesFilter.MatchesPreferencesFilter(userProfile);
            var userPreferencesFilter = preferencesFilter.Compose<User, UserProfile>(user =>
                user.UserProfile!
            );

            return await _context
                .Users.Where(u => u.Id != userProfile.UserId)
                .Where(userPreferencesFilter)
                .CountAsync();
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
            return await _context
                .Users.Include(u => u.Media)
                .Include(u => u.UserProfile)
                .ThenInclude(up => up != null ? up.UserProfileGenders : null)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<BlockedUser?> BlockUser(BlockedUser blockedUser)
        {
            _context.BlockedUsers.Add(blockedUser);
            await _context.SaveChangesAsync();
            return blockedUser;
        }

        public async Task<bool> UnBlockUser(User currentUser, BlockUserDto unblockUserDto)
        {
            var blockedUser = await _context.BlockedUsers.FirstOrDefaultAsync(b =>
                b.BlockerUserId == currentUser.Id && b.BlockedUserId == unblockUserDto.BlockedUserId
            );

            if (blockedUser == null)
            {
                throw new InvalidDataException("Blocked user not found.");
            }

            _context.BlockedUsers.Remove(blockedUser);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<BlockedUser>> UsersIbBlocked(string userId)
        {
            return await _context.BlockedUsers.Where(b => b.BlockerUserId == userId).ToListAsync();
        }
    }
}
