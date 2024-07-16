using api.Models;

namespace api.Interfaces
{
    public interface IQuestionCategoryRepository
    {
        Task<IEnumerable<QuestionCategory>> GetAllAsync();
        Task<QuestionCategory?> GetByIdAsync(int id);
        Task<QuestionCategory> CreateAsync(QuestionCategory category);
        Task UpdateAsync(QuestionCategory category);
        Task DeleteAsync(int id);
    }
}
