using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private string name;
    private List<Topping> toppings;
    private Dough dough;
    private int numberOfToppings;

    public Pizza(string name, int numberOfToppings) : this()
    {
        this.Name = name;
        this.NumberOfToppings = numberOfToppings;
    }

    public Pizza()
    {
        this.toppings = new List<Topping>();
    }

    public int NumberOfToppings
    {
        get { return this.numberOfToppings; }
        protected set
        {
            if (value < 0 || value > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.numberOfToppings = value;
        }
    }

    public string Name
    {
        get { return this.name; }
        protected set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            this.name = value;
        }
    }

    public Dough Dough
    {
        set { this.dough = value; }
    }

    public void AddTopping(Topping topping)
    {
        this.toppings.Add(topping);
    }

    public double GetCalories()
    {
        var totalPizzaCalories = this.toppings.Sum(cal => cal.GetCalories()) + this.dough.GetCalories();

        return totalPizzaCalories;
    }
}