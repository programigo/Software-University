namespace _11.PokemonTrainer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            string input;

            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
            

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] elements = input.Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
                string trainerName = elements[0];
                string pokemonName = elements[1];
                string pokemonElement = elements[2];
                int pokemonHealth = int.Parse(elements[3]);

                Trainer trainer = new Trainer(trainerName, 0);
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, trainer);
                }

                trainers[trainerName].AddPokemon(pokemon);
            }

            string element;

            while ((element = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    foreach (var pokemon in trainer.Value.Pokemons)
                    {
                        if (pokemon.Element == element)
                        {
                            trainer.Value.IncreaseBadges();
                            break;
                        }
                        else
                        {
                            pokemon.ReduceHealth();
                        }
                    }

                    trainer.Value.RemovePokemons();
                }
            }

            var sortedTrainers = trainers.OrderByDescending(badges => badges.Value.NumberOfBadges);

            foreach (var sortedTrainer in sortedTrainers)
            {

                Console.WriteLine(
                    $"{sortedTrainer.Value.Name} {sortedTrainer.Value.NumberOfBadges} {sortedTrainer.Value.Pokemons.Count}");
            }
        }
    }
}
