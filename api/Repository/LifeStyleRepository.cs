using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class LifeStyleRepository : ILifeStyleRepository
    {
        private readonly ApplicationDBContext _context;
        public LifeStyleRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<LifeStyle>> GetAllAsync()
        {
            return await _context.LifeStyles.ToListAsync();
        }

    }
}