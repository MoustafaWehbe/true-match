using System.Text.Json;
using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class RoomMapper
    {
        public static RoomDto ToRoomDto(this Room roomModel, string userId = "")
        {
            return new RoomDto
            {
                Id = roomModel.Id,
                Description = roomModel.Description,
                Title = roomModel.Title,
                ScheduledAt = roomModel.ScheduledAt,
                FinishedAt = roomModel.FinishedAt,
                ParticipantCount = roomModel.RoomParticipants.Count,
                IsParticipanting = roomModel.RoomParticipants.Any(rp => rp.UserId == userId),
                User = roomModel.User?.ToUserSimplifiedDto(),
                CreatedAt = roomModel.CreatedAt,
                UpdatedAt = roomModel.UpdatedAt,
                Offers = roomModel.Offers,
                RoomMetaData = roomModel.RoomMetaData != null ? JsonSerializer.Deserialize<RoomMetaData>(roomModel.RoomMetaData) : null,
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