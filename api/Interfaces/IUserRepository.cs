using api.Dtos;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync(UserQueryObject query);
        Task<int> GetTotalUsersAsync();
        int GetTotalPages(int pageSize, int totalUsers);
        Task<User?> GetByIdAsync(string userId);
        Task<BlockedUser?> BlockUser(BlockedUser blockedUser);
        Task<bool> UnBlockUser(User currentUser, BlockUserDto unblockUserDto);
    }
}