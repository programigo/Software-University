using System.Text;

public class Tesla : ICar, IElectricCar
{
    public string Model { get; protected set; }
    public string Color { get; protected set; }
    public int Battery { get; protected set; }

    public Tesla(string model, string color, int battery)
    {
        this.Model = model;
        this.Color = color;
        this.Battery = battery;
    }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Color} {nameof(Tesla)} {this.Model} with {this.Battery} Batteries");
        sb.AppendLine($"{this.Start()}");
        sb.AppendLine($"{this.Stop()}");

        return sb.ToString().Trim();
    }
}