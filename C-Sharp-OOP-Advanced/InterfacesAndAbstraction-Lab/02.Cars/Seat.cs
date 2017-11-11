using System.Text;

public class Seat : ICar
{
    public string Model { get; protected set; }
    public string Color { get; protected set; }

    public Seat(string model, string color)
    {
        this.Model = model;
        this.Color = color;
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
        sb.AppendLine($"{this.Color} {nameof(Seat)} {this.Model}");
        sb.AppendLine($"{this.Start()}");
        sb.AppendLine($"{this.Stop()}");

        return sb.ToString().Trim();
    }
}