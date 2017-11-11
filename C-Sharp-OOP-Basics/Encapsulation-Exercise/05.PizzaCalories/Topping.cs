using System;

public class Topping
{
    private string type;
    private double weight;

    public Topping(string type, double weight)
    {
        this.Type = type;
        this.Weight = weight;
    }

    public double Weight
    {
        get { return this.weight; }
        protected set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
            }
            this.weight = value;
        }
    }

    public string Type
    {
        get { return this.type; }
        protected set
        {
            if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            this.type = value;
        }
    }

    public double GetCalories()
    {
        var result = 2 * this.Weight;

        if (this.Type.ToLower() == "meat")
        {
            result *= 1.2;
        }
        else if (this.Type.ToLower() == "veggies")
        {
            result *= 0.8;
        }
        else if (this.Type.ToLower() == "cheese")
        {
            result *= 1.1;
        }
        else if (this.Type.ToLower() == "sauce")
        {
            result *= 0.9;
        }

        return result;
    }
}