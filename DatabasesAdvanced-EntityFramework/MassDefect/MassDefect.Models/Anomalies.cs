using System.Collections.Generic;

public class Anomalies
{
    public Anomalies()
    {
        this.Persons = new List<Persons>();
    }

    public int Id { get; set; }

    public Planets OriginPlanet { get; set; }

    public Planets TeleportPlanet { get; set; }

    public ICollection<Persons> Persons { get; set; }
}