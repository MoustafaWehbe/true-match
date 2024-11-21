using api.Dtos;
using api.Models;
using AutoMapper;

namespace api.Mappers
{
    public class CountryMappingProfile : Profile
    {
        public CountryMappingProfile()
        {
            CreateMap<Country, CountryDto>();
        }
    }
}
