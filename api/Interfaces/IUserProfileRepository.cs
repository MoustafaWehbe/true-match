using api.Models;

namespace api.Interfaces
{
    public interface IUserProfileRepository
    {
        Task<UserProfile> CreateAsync(UserProfile userProfile);
        Task<UserProfile?> GetByIdAsync(int id);
    }
}