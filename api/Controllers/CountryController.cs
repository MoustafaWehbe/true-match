using api.Dtos;
using api.Helpers;
using api.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountriesController(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<List<CountryDto>>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var countries = await _countryRepository.GetAllCountriesAsync();
            var countryDtos = _mapper.Map<IEnumerable<CountryDto>>(countries);
            return Ok(ResponseHelper.CreateSuccessResponse(countryDtos));
        }

        [HttpGet("{id:guid}")]
        [Authorize]
        [ProducesResponseType(typeof(ApiResponse<CountryDto>), 200)]
        public async Task<IActionResult> GetCountryById(Guid id)
        {
            var country = await _countryRepository.GetCountryByIdAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            var countryDto = _mapper.Map<CountryDto>(country);

            return Ok(ResponseHelper.CreateSuccessResponse(countryDto));
        }

        // [HttpGet("location")]
        // public async Task<IActionResult> GetCountryByLocation([FromQuery] double latitude, [FromQuery] double longitude)
        // {
        //     var location = new Point(longitude, latitude) { SRID = 4326 }; // Ensure SRID matches your DB
        //     var country = await _countryRepository.GetCountryByLocationAsync(location);

        //     if (country == null)
        //         return NotFound("Location does not belong to any country.");

        //     return Ok(country);
        // }
    }
}
