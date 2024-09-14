using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class MatchMapper
    {
        public static MatchDto ToMatchDto(this Match matchModel)
        {
            return new MatchDto
            {
                Id = matchModel.Id,
                User1 = matchModel.User1?.ToUserSimplifiedDto(),
                User2 = matchModel.User2?.ToUserSimplifiedDto(),
                Origin = matchModel.Origin,
                CreatedAt = matchModel.CreatedAt,
                UpdatedAt = matchModel.UpdatedAt,
            };
        }

        public static Match ToMatchFromCreate(this CreateMatchDto matchDto, string userId)
        {
            return new Match
            {
                User1Id = userId,
                Origin = matchDto.Origin,
                User2Id = matchDto.User2Id
            };
        }
    }
}