using api.Models;

namespace api.Interfaces
{
    public interface IMediaRepository
    {
        Task<Media> CreateAsync(Media media);
    }
}