using ReviewService.Data;
using ReviewService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReviewService
{
    public class Seed
    {
        private readonly DataContext dataContext;

        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.PokemonOwners.Any())
            {
                var pokemonOwners = new List<PokemonOwner>
                {
                    new PokemonOwner
                    {
                        Pokemon = new Pokemon
                        {
                            Name = "Pikachu",
                            BirthDate = new DateTime(1903, 1, 1),
                            PokemonCategories = new List<PokemonCategory>
                            {
                                new PokemonCategory { Category = new Category { Name = "Electric" } }
                            },
                            Reviews = new List<Review>
                            {
                                new Review
                                {
                                    Title = "Pikachu",
                                    Text = "Pikachu is the best pokemon, because it is electric",
                                    Rating = 5,
                                    Reviewer = new Reviewer { FirstName = "Teddy", LastName = "Smith" }
                                },
                                new Review
                                {
                                    Title = "Pikachu",
                                    Text = "Pikachu is the best at killing rocks",
                                    Rating = 5,
                                    Reviewer = new Reviewer { FirstName = "Taylor", LastName = "Jones" }
                                },
                                new Review
                                {
                                    Title = "Pikachu",
                                    Text = "Pikachu, Pikachu, Pikachu",
                                    Rating = 1,
                                    Reviewer = new Reviewer { FirstName = "Jessica", LastName = "McGregor" }
                                },
                            }
                        },
                        Owner = new Owner
                        {
                            Name = "Jack",
                            Gym = "Brock's Gym",
                            Country = new Country { Name = "Kanto" }
                        }
                    },
                    // Add more PokemonOwner objects as needed
                };

                dataContext.PokemonOwners.AddRange(pokemonOwners);
                dataContext.SaveChanges();
            }
        }
    }
}
