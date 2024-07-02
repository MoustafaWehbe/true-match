using api.Models;

namespace api.Interfaces
{
    public interface IInterestRepository
    {
        Task<List<Interest>> GetAllAsync();
    }
}