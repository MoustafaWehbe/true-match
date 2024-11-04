using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class MessageMapper
    {
        public static MessageDto ToMessageDto(this Message messageModel)
        {
            return new MessageDto
            {
                Id = messageModel.Id,
                SenderId = messageModel.SenderId,
                ReceiverId = messageModel.ReceiverId,
                Content = messageModel.Content,
                CreatedAt = messageModel.CreatedAt,
                UpdatedAt = messageModel.UpdatedAt,
                Status = messageModel.Status,
            };
        }

        public static Message ToMessageFromCreate(this CreateMessageDto messageDto)
        {
            return new Message
            {
                Id = messageDto.Id,
                SenderId = messageDto.SenderId,
                ReceiverId = messageDto.ReceiverId,
                Content = messageDto.Content,
                CreatedAt = messageDto.CreatedAt,
                UpdatedAt = messageDto.UpdatedAt,
                Status = messageDto.Status,
            };
        }
    }
}