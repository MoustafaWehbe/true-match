using Microsoft.EntityFrameworkCore;
using api.Models;
using api.Interfaces;
using api.Data;

namespace api.Repository
{
    public class GenderRepository : IGenderRepository
    {
        private readonly ApplicationDBContext _context;

        public GenderRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Gender>> GetAllAsync()
        {
            return await _context.Genders
                .ToListAsync();
        }
    }
}
