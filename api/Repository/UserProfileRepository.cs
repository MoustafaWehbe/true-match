using api.Data;
using api.Dtos;
using api.Interfaces;
using api.Mappers;
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

        public async Task<UserProfile> CreateOrUpdateAsync(
            CreateOrUpdateUserProfileDto userProfileDto,
            string userId
        )
        {
            var existingUserProfile = await GetByUserId(userId);
            if (existingUserProfile != null)
            {
                userProfileDto.ToUserProfileFromUpdate(existingUserProfile, userId);
                _context.UserProfiles.Update(existingUserProfile);
                await _context.SaveChangesAsync();

                if (
                    userProfileDto.UserProfileGenders != null
                    && userProfileDto.UserProfileGenders.Count() > 0
                )
                {
                    var existingUserProfileGenders = await _context
                        .UserProfileGenders.Where(upg =>
                            upg.UserProfileId == existingUserProfile.Id
                        )
                        .ToListAsync();
                    if (existingUserProfileGenders.Any())
                    {
                        _context.UserProfileGenders.RemoveRange(existingUserProfileGenders);
                    }

                    foreach (var upgDto in userProfileDto.UserProfileGenders)
                    {
                        _context.UserProfileGenders.Add(
                            upgDto.ToUserProfileGenderFromCreate(existingUserProfile.Id)
                        );
                    }
                    await _context.SaveChangesAsync();
                }

                return existingUserProfile;
            }
            else
            {
                var userProfile = userProfileDto.ToUserProfileFromCreate(userId);

                if (
                    userProfileDto.UserProfileGenders != null
                    && userProfileDto.UserProfileGenders.Count() > 0
                )
                {
                    userProfile.UserProfileGenders.AddRange(
                        userProfileDto.UserProfileGenders.Select(upg =>
                            upg.ToUserProfileGenderFromCreate(userProfile.Id)
                        )
                    );
                }

                if (
                    userProfileDto.UserProfileGenders != null
                    && userProfileDto.UserProfileGenders.Count() > 0
                )
                {
                    userProfile.UserProfileGenders.AddRange(
                        userProfileDto.UserProfileGenders.Select(upg =>
                            upg.ToUserProfileGenderFromCreate(userProfile.Id)
                        )
                    );
                }

                _context.UserProfiles.Add(userProfile);
                await _context.SaveChangesAsync();

                return userProfile;
            }
        }

        public async Task<UserProfile?> GetByIdAsync(Guid id)
        {
            return await _context
                .UserProfiles.Include(a => a.User)
                .Include(a => a.UserProfileGenders)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<UserProfile?> GetByUserId(string userId)
        {
            var query = _context.UserProfiles.Include(up => up.UserProfileGenders);

            return await query.FirstOrDefaultAsync(up => up.UserId == userId);
        }
    }
}
