using api.Models;

namespace api.Interfaces
{
    public interface ILifeStyleRepository
    {
        Task<List<LifeStyle>> GetAllAsync();
    }
}