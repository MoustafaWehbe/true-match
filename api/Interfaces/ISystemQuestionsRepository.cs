using api.Models;

namespace api.Interfaces
{
    public interface ISystemQuestionRepository
    {
        Task<IEnumerable<SystemQuestion>> GetAllAsync();
        IQueryable<SystemQuestion> GetAll();
        Task<SystemQuestion?> GetByIdAsync(int id);
        Task<SystemQuestion> CreateAsync(SystemQuestion question);
        Task UpdateAsync(SystemQuestion question);
        Task DeleteAsync(int id);
    }
}
