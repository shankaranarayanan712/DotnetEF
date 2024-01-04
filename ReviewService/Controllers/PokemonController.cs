using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReviewService.Dto;
using ReviewService.Interfaces;
using ReviewService.Models;

namespace ReviewService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private IPokemonRepository _pokemonRepository;
        private IMapper _maper;

        public PokemonController(IPokemonRepository pokemonRepository, IMapper mapper)
           
        {
            _pokemonRepository = pokemonRepository;
            _maper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ICollection<Pokemon>))]
        public IActionResult GetPokemons()
        {
            var pokemons = _maper.Map<List<PokemonDto>>(_pokemonRepository.GetPokemons());
            if(!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            return new OkObjectResult(pokemons);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(404)]
        public IActionResult GetPokemonById(int id)
        {
            var pokemon = _maper.Map<PokemonDto>(_pokemonRepository.GetPokemonById(id));

            if (pokemon == null)
            {
                return NotFound();
            }

            return Ok(pokemon);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        [ProducesResponseType(404)]
        public IActionResult CreatePokemon([FromBody] PokemonDto pokemonDto)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            var pokemon = _maper.Map<Pokemon>(pokemonDto);
            var savedPokemon = _pokemonRepository.SavePokemon(pokemon);
            var savedPokemonDto = _maper.Map<PokemonDto>(savedPokemon);

            return Ok(savedPokemonDto);
        }


    }
}
