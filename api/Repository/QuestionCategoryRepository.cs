using Microsoft.EntityFrameworkCore;
using api.Models;
using api.Interfaces;
using api.Data;

namespace api.Repository
{
    public class QuestionCategoryRepository : IQuestionCategoryRepository
    {
        private readonly ApplicationDBContext _context;

        public QuestionCategoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuestionCategory>> GetAllAsync()
        {
            return await _context.QuestionCategories.ToListAsync();
        }

        public async Task<QuestionCategory?> GetByIdAsync(int id)
        {
            return await _context.QuestionCategories.FindAsync(id);
        }

        public async Task<QuestionCategory> CreateAsync(QuestionCategory category)
        {
            _context.QuestionCategories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task UpdateAsync(QuestionCategory category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await _context.QuestionCategories.FindAsync(id);
            if (category != null)
            {
                _context.QuestionCategories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}
