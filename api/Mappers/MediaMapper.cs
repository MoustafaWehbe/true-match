using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class MediaMapper
    {
        public static MediaDto ToMediaDto(this Media mediaModel)
        {
            return new MediaDto
            {
                Id = mediaModel.Id,
                Url = mediaModel.Url,
                CreatedAt = mediaModel.CreatedAt,
                UpdatedAt = mediaModel.UpdatedAt,
                MediaType = mediaModel.MediaType,
                UserId = mediaModel.UserId,
            };
        }
    }
}
