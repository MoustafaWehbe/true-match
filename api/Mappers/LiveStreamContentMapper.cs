using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class LiveStreamContentMapper
    {
        public static LiveStreamContentDto ToLiveStreamContentDto(this LiveStreamContent liveStreamContentModel)
        {
            return new LiveStreamContentDto
            {
                Id = liveStreamContentModel.Id,
                Title = liveStreamContentModel.Title,
                Description = liveStreamContentModel.Description,
                Duration = liveStreamContentModel.Duration,
                Order = liveStreamContentModel.Order,
                CreatedAt = liveStreamContentModel.CreatedAt,
                UpdatedAt = liveStreamContentModel.UpdatedAt,
            };
        }

    }
}