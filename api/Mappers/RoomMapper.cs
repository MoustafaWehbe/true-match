using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class RoomMapper
    {
        public static RoomDto ToRoomDto(this Room roomModel)
        {
            return new RoomDto
            {
                Id = roomModel.Id,
                Description = roomModel.Description,
                Status = roomModel.Status,
                Title = roomModel.Title,
                ScheduledAt = roomModel.ScheduledAt,
                FinishedAt = roomModel.FinishedAt,
                RoomParticipants = roomModel.RoomParticipants,
                User = roomModel.User?.ToUserSimplifiedDto(),
                CreatedAt = roomModel.CreatedAt,
                UpdatedAt = roomModel.UpdatedAt,
                Offers = roomModel.Offers,
                QuestionsCategories = roomModel.QuestionsCategories
            };
        }

        public static Room ToRoomFromCreate(this CreateRoomDto roomDto, string userId)
        {
            return new Room
            {
                Title = roomDto.Title,
                Description = roomDto.Description,
                ScheduledAt = roomDto.ScheduledAt,
                QuestionsCategories = roomDto.QuestionsCategories,
                UserId = userId
            };
        }
    }
}