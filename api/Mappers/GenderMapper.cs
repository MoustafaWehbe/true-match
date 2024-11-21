using System.Text.Json;
using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class GenderMapper
    {
        public static GenderDto ToGenderDto(this Gender genderModel)
        {
            return new GenderDto
            {
                Id = genderModel.Id,
                Name = genderModel.Name,
                Description = genderModel.Description,
                ParentId = genderModel.ParentId,
                Children = genderModel.Children?.Select(g => g.ToGenderDto()).ToList(),
            };
        }
    }
}
