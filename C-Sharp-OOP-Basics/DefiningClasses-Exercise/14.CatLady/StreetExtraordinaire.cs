public class StreetExtraordinaire : Cat
{
    private int meowingDecibels;

    public StreetExtraordinaire(string name, int meowingDecibels) : base(name)
    {
        this.meowingDecibels = meowingDecibels;
    }

    public override string ToString()
    {
        return $"StreetExtraordinaire {this.Name} {this.meowingDecibels}";
    }
}
