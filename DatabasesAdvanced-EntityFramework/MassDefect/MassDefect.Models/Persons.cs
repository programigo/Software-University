using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Persons
{
    public Persons()
    {
        this.Anomalies = new List<Anomalies>();
    }

    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public Planets HomePlanet { get; set; }

    public ICollection<Anomalies> Anomalies { get; set; }
}