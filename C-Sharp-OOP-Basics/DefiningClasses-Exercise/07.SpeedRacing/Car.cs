using System;

public class Car
{
    private string model;
    private double fuelAmount;
    private double fuelConsumption;
    private double distanceTraveled;

    public Car(string model, double fuelAmount, double fuelConsumption)
    {
        this.model = model;
        this.fuelAmount = fuelAmount;
        this.fuelConsumption = fuelConsumption;
    }

    public string Model
    {
        get { return this.model; }
    }

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        set { this.fuelAmount = value; }
    }

    public double FuelConsumption
    {
        get { return this.fuelConsumption; }
    }

    public double DistanceTraveled
    {
        get { return this.distanceTraveled; }
        set { this.distanceTraveled = value; }
    }

    public void TryDriveDistance(double amountOfKm)
    {
        if (amountOfKm * this.FuelConsumption <= this.FuelAmount)
        {
            this.FuelAmount -= amountOfKm * this.FuelConsumption;
            this.DistanceTraveled += amountOfKm;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}