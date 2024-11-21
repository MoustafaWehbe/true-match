using AutoMapper;
using api.Dtos;
using api.Models;

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
