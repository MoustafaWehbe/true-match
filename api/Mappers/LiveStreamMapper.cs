using api.Dtos.LiveStream;
using api.Models;

namespace api.Mappers
{
    public static class LiveStreamMapper
    {
        public static LiveStreamDto ToLiveStreamDto(this LiveStream liveStreamModel)
        {
            return new LiveStreamDto
            {
                Id = liveStreamModel.Id,
                Description = liveStreamModel.Description,
                HasStarted = liveStreamModel.HasStarted,
                ScheduledAt = liveStreamModel.ScheduledAt,
                FinishedAt = liveStreamModel.FinishedAt,
                CreatedAt = liveStreamModel.CreatedAt,
                UpdatedAt = liveStreamModel.UpdatedAt,
            };
        }

        public static LiveStream ToLiveStreamFromCreate(this CreateLiveStreamDto liveStreamDto, string userId)
        {
            return new LiveStream
            {
                Title = liveStreamDto.Title,
                Description = liveStreamDto.Description,
                ScheduledAt = liveStreamDto.ScheduledAt,
                UserId = userId
            };
        }
    }
}