using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Interest;
using api.Models;

namespace api.Mappers
{
    public static class InterestMapper
    {
        public static InterestDto ToInterestDto(this Interest interestModel)
        {
            return new InterestDto
            {
                Id = interestModel.Id,
                Name = interestModel.Name,
                CreatedAt = interestModel.CreatedAt,
                UpdatedAt = interestModel.UpdatedAt,
            };
        }

    }
}