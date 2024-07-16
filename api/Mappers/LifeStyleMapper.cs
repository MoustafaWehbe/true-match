using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class LifeStyleMapper
    {
        public static LifeStyleDto ToLifeStyleDto(this LifeStyle lifeStyleModel)
        {
            return new LifeStyleDto
            {
                Id = lifeStyleModel.Id,
                Name = lifeStyleModel.Name,
                CreatedAt = lifeStyleModel.CreatedAt,
                UpdatedAt = lifeStyleModel.UpdatedAt,
            };
        }

    }
}