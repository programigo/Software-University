using System.Collections.Generic;

public class Trainer
{
    private string name;
    private int nmberOfBadges;
    private List<Pokemon> pokemons;

    public Trainer(string name, int nmberOfBadges)
    {
        this.name = name;
        this.nmberOfBadges = nmberOfBadges;
        this.pokemons = new List<Pokemon>();
    }

    public string Name
    {
        get { return this.name; }
    }

    public IReadOnlyCollection<Pokemon> Pokemons
    {
        get { return this.pokemons.AsReadOnly(); }
    }

    public int NumberOfBadges
    {
        get { return this.nmberOfBadges; }
    }

    public void AddPokemon(Pokemon pokemon)
    {
        this.pokemons.Add(pokemon);
    }

    public void IncreaseBadges()
    {
        this.nmberOfBadges++;
    }

    public void RemovePokemons()
    {
        this.pokemons.RemoveAll(pokemon => pokemon.Health <= 0);
    }
}
