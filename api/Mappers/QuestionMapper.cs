using api.Dtos;
using api.Models;

namespace api.Mappers
{
    public static class QuestionMapper
    {
        public static SystemQuestionDto ToSystemQuestionDto(this SystemQuestion questionModel)
        {
            return new SystemQuestionDto
            {
                Id = questionModel.Id,
                Name = questionModel.Name,
                CategoryId = questionModel.CategoryId
            };
        }
    }
}