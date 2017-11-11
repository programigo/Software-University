using System.Text;

public class Ferrari : ICar
{
    public Ferrari(string driver)
    {
        this.Model = "488-Spider";
        this.Driver = driver;
    }

    public string Model { get; }

    public string Driver { get; }

    public string UseBreaks()
    {
        return "Brakes!";
    }

    public string PushThGas()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Model}/{this.UseBreaks()}/{this.PushThGas()}/{this.Driver}");

        return sb.ToString().Trim();
    }
}
