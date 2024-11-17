using api.Data;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.OpenApi.Any;

namespace api.Repository
{
    public class MediaRepository : IMediaRepository
    {
        private readonly ApplicationDBContext _context;
        public MediaRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Media> CreateAsync(Media media)
        {
            try
            {
                _context.Media.Add(media);
                await _context.SaveChangesAsync();
                return media;

            }
            catch (Exception ex)
            {
                var errorResponse = ResponseHelper.CreateErrorResponse<AnyType>(ex.Message);
                return StatusCode(500, errorResponse);
            }
        }

        private Media StatusCode(int v, object errorResponse)
        {
            throw new NotImplementedException();
        }
    }
}