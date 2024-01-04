using AutoMapper;
using ReviewService.Dto;
using ReviewService.Models;

namespace ReviewService
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PokemonDto, Pokemon>();
            CreateMap<Pokemon, PokemonDto>();
        }
    }
}
