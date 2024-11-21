using api.Dtos;
using api.Models;

namespace api.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<UserProfile> CreateOrUpdateAsync(
            CreateOrUpdateUserProfileDto userProfileDto,
            string userId
        );
        Task<UserProfile?> GetByUserId(string userId);
        Task<UserProfile?> GetByIdAsync(Guid id);
    }
}
