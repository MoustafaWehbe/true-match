using Microsoft.EntityFrameworkCore;
using api.Models;
using api.Interfaces;
using api.Data;

namespace api.Repository
{
    public class SystemQuestionRepository : ISystemQuestionRepository
    {
        private readonly ApplicationDBContext _context;

        public SystemQuestionRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public IQueryable<SystemQuestion> GetAll()
        {
            return _context.SystemQuestions.AsQueryable();
        }

        public async Task<IEnumerable<SystemQuestion>> GetAllAsync()
        {
            return await _context.SystemQuestions
                .ToListAsync();
        }

        public async Task<SystemQuestion?> GetByIdAsync(Guid id)
        {
            return await _context.SystemQuestions
                .Include(sq => sq.Category)
                .FirstOrDefaultAsync(sq => sq.Id == id);
        }

        public async Task<SystemQuestion> CreateAsync(SystemQuestion question)
        {
            _context.SystemQuestions.Add(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task UpdateAsync(SystemQuestion question)
        {
            _context.Entry(question).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var question = await _context.SystemQuestions.FindAsync(id);
            if (question != null)
            {
                _context.SystemQuestions.Remove(question);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException("user not found.");
            }
        }
    }
}
