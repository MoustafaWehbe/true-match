using api.Models;

namespace api.Interfaces
{
    public interface IAvailableDescriptorRepository
    {
        Task<IEnumerable<AvailableDescriptor>> GetAllAsync();
    }
}
