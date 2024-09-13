using Microsoft.EntityFrameworkCore;
using api.Models;
using api.Interfaces;
using api.Data;

namespace api.Repository
{
    public class AvailableDescriptorRepository : IAvailableDescriptorRepository
    {
        private readonly ApplicationDBContext _context;

        public AvailableDescriptorRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AvailableDescriptor>> GetAllAsync()
        {
            return await _context.AvailableDescriptors
                .ToListAsync();
        }
    }
}
