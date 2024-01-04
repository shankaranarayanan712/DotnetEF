using ReviewService.Models;

namespace ReviewService.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemonById(int id);
        Pokemon SavePokemon(Pokemon pokemon);
    }
}
