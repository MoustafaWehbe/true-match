using api.Models;

namespace api.Interfaces
{
    public interface IGenderRepository
    {
        Task<IEnumerable<Gender>> GetAllAsync();
    }
}
