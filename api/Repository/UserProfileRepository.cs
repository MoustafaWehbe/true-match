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

        public async Task<UserProfile> CreateOrUpdateAsync(CreateOrUpdateUserProfileDto userProfileDto, string userId)
        {
            var userProfileAlreadyCreated = await GetByUserId(userId);
            if (userProfileAlreadyCreated != null)
            {
                var userProfileToUpdate = userProfileDto.ToUserProfileFromUpdate(userProfileAlreadyCreated, userId);

                if (userProfileDto.UserProfileGenders != null && userProfileDto.UserProfileGenders.Count() > 0)
                {
                    var existingUserProfileGenders = await _context.UserProfileGenders.Where(upg => upg.UserProfileId == userProfileAlreadyCreated.Id).ToListAsync();
                    _context.UserProfileGenders.RemoveRange(existingUserProfileGenders);

                    userProfileToUpdate.UserProfileGenders
                      .AddRange(userProfileDto.UserProfileGenders
                          .Select(
                              upg => upg.ToUserProfileGenderFromCreate(userProfileToUpdate.Id)
                          )
                      );
                }

                _context.UserProfiles.Update(userProfileToUpdate);
                await _context.SaveChangesAsync();

                return userProfileToUpdate;
            }
            else
            {
                var userProfile = userProfileDto.ToUserProfileFromCreate(userId);

                if (userProfileDto.UserProfileGenders != null && userProfileDto.UserProfileGenders.Count() > 0)
                {
                    userProfile.UserProfileGenders
                        .AddRange(userProfileDto.UserProfileGenders
                            .Select(
                                upg => upg.ToUserProfileGenderFromCreate(userProfile.Id)
                            )
                        );
                }

                if (userProfileDto.UserProfileGenders != null && userProfileDto.UserProfileGenders.Count() > 0)
                {
                    userProfile.UserProfileGenders
                        .AddRange(userProfileDto.UserProfileGenders
                            .Select(
                                upg => upg.ToUserProfileGenderFromCreate(userProfile.Id)
                            )
                        );
                }

                _context.UserProfiles.Add(userProfile);
                await _context.SaveChangesAsync();

                return userProfile;
            }
        }

        public async Task<UserProfile?> GetByIdAsync(int id)
        {
            return await _context.UserProfiles.Include(a => a.User).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<UserProfile?> GetByUserId(string userId)
        {
            return await _context.UserProfiles.AsNoTracking().FirstOrDefaultAsync(up => up.UserId == userId);
        }
    }
}