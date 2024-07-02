using api.Helpers;
using api.Models;

namespace api.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync(UserQueryObject query);
        Task<int> GetTotalUsersAsync();
        Task<int> GetTotalPagesAsync(int pageSize);
    }
}