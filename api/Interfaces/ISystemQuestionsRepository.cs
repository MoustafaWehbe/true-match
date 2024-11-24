using api.Models;

namespace api.Interfaces
{
    public interface ISystemQuestionRepository
    {
        Task<IEnumerable<SystemQuestion>> GetAllAsync();
        IQueryable<SystemQuestion> GetAll();
        Task<SystemQuestion?> GetByIdAsync(Guid id);
        Task<SystemQuestion> CreateAsync(SystemQuestion question);
        Task UpdateAsync(SystemQuestion question);
        Task DeleteAsync(Guid id);
        Task<List<SystemQuestion>> GenerateRandomQuestions(List<Guid> categories);
    }
}
