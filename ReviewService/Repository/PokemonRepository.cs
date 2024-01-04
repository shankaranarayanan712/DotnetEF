using ReviewService.Data;
using ReviewService.Interfaces;
using ReviewService.Models;

namespace ReviewService.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private DataContext _context;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemons.OrderBy(p => p.Id).ToList();
        }

        public Pokemon GetPokemonById(int id)
        {
            return _context.Pokemons.FirstOrDefault(p => p.Id == id);
        }

        public Pokemon SavePokemon(Pokemon pokemon)
        {
            _context.Pokemons.Add(pokemon);
            _context.SaveChanges();
            return pokemon;
        }


    }
}
