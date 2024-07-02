using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class InterestRepository : IInterestRepository
    {
        private readonly ApplicationDBContext _context;
        public InterestRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<Interest>> GetAllAsync()
        {
            return await _context.Interests.ToListAsync();
        }

    }
}