using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace api.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDBContext _context;

        public CountryRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country?> GetCountryByIdAsync(Guid id)
        {
            return await _context.Countries.FindAsync(id);
        }

        public async Task<Country?> GetCountryByLocationAsync(Point location)
        {
            return await _context.Countries.FirstOrDefaultAsync(c => c.WkbGeometry.Contains(location));
        }
    }
}
