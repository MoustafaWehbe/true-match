using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class RoomContentMapper
    {
        public static RoomContentDto ToRoomContentDto(this RoomContent roomContentModel)
        {
            return new RoomContentDto
            {
                Id = roomContentModel.Id,
                Title = roomContentModel.Title,
                Description = roomContentModel.Description,
                Duration = roomContentModel.Duration,
                Order = roomContentModel.Order,
                CreatedAt = roomContentModel.CreatedAt,
                UpdatedAt = roomContentModel.UpdatedAt,
            };
        }

    }
}