using AutoMapper;
using ReviewService.Dto;
using ReviewService.Models;

namespace ReviewService.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
                 CreateMap<Pokemon, PokemonDto>();
        }
    }
}
