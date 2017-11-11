using System.Collections.Generic;

public class Car
{
    private string model;
    private Engine engine;
    private Cargo cargo;
    private List<Tire> tires;

    public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
    {
        this.model = model;
        this.engine = engine;
        this.cargo = cargo;
        this.tires = new List<Tire>(4);
    }

    public Cargo Cargo
    {
        get { return this.cargo; }
    }

    public Engine Engine
    {
        get { return this.engine; }
    }

    public string Model
    {
        get { return this.model; }
    }

    public List<Tire> Tires
    {
        get { return this.tires; }
    }

    public void AddTire(Tire tire)
    {
        this.tires.Add(tire);
    }
}