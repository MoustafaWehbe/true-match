using AutoMapper;
using api.Dtos;
using api.Models;

namespace api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CountryDto>();
        }
    }
}
