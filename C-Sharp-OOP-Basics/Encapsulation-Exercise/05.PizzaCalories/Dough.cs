using System;

public class Dough
{
    private string flourType;
    private string bakingTechnique;
    private double weight;

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        this.FlourType = flourType;
        this.BakingTechnique = bakingTechnique;
        this.Weight = weight;
    }

    public double Weight
    {
        get { return this.weight; }
        protected set
        {
            if (value < 1 || value > 200)
            {
                throw new ArgumentException("Dough weight should be in the range [1..200].");
            }
            this.weight = value;
        }
    }

    public string BakingTechnique
    {
        get { return this.bakingTechnique; }
        protected set
        {
            if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.bakingTechnique = value;
        }
    }

    public string FlourType
    {
        get { return this.flourType; }
        protected set
        {
            if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
            {
                throw new ArgumentException("Invalid type of dough.");
            }
            this.flourType = value;
        }
    }

    public double GetCalories()
    {
        var result = 2 * this.Weight;

        if (this.FlourType.ToLower() == "white")
        {
            result *= 1.5;
        }
        else if (this.FlourType.ToLower() == "wholegrain")
        {
            result *= 1.0;
        }

        if (this.BakingTechnique.ToLower() == "crispy")
        {
            result *= 0.9;
        }
        else if (this.BakingTechnique.ToLower() == "chewy")
        {
            result *= 1.1;
        }
        else if (this.BakingTechnique.ToLower() == "homemade")
        {
            result *= 1.0;
        }

        return result;
    }
}