using api.Models;
using NetTopologySuite.Geometries;

namespace api.Repositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllCountriesAsync();
        Task<Country?> GetCountryByIdAsync(Guid id);
        Task<Country?> GetCountryByLocationAsync(Point location);
    }
}
