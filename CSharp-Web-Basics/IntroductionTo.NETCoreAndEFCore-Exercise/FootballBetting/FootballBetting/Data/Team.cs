using System.Collections.Generic;

public class Team
{
    public int Id { get; set; }

    public string Name { get; set; }

    public byte Logo { get; set; }

    public string Initials { get; set; }

    public int PrimaryColorId { get; set; }

    public Color PrimaryKitColor { get; set; }

    public int SecondaryColorId { get; set; }

    public Color SecondaryKitColor { get; set; }

    public int TownId { get; set; }

    public Town Town { get; set; }

    public decimal Budget { get; set; }

    public List<Player> Players { get; set; } = new List<Player>();
}