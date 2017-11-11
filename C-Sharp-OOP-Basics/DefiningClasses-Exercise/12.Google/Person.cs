using System.Collections.Generic;

public class Person
{
    private string name;
    private Company company;
    private Car car;
    private List<Parent> parents;
    private List<Children> childrens;
    private List<Pokemon> pokemons;

    public Person(string name)
    {
        this.name = name;
        this.pokemons = new List<Pokemon>();
        this.childrens = new List<Children>();
        this.parents = new List<Parent>();
    }

    public Person(string name, Car car)
    {
        this.name = name;
        this.car = car;
    }

    public Person(string name, Company company)
    {
        this.name = name;
        this.company = company;
    }

    public Person(string name, Company company, Car car)
    {
        this.name = name;
        this.company = company;
        this.car = car;
    }

    public string Name
    {
        get
        {
            return this.name;
        }
    }

    public Company Company
    {
        get { return this.company; }
        set
        {
            this.company = value;
        }
    }

    public Car Car
    {
        get
        {
            return this.car;
        }
        set
        {
            this.car = value;
        }
    }

    public List<Pokemon> Pokemons { get { return this.pokemons; } }

    public List<Parent> Parents { get { return this.parents; } }

    public List<Children> Childrens { get { return this.childrens; } }

    public void AddPokemon(Pokemon pokemon)
    {
        this.pokemons.Add(pokemon);
    }

    public void AddParent(Parent parent)
    {
        this.parents.Add(parent);
    }

    public void AddChildren(Children child)
    {
        this.childrens.Add(child);
    }
}
