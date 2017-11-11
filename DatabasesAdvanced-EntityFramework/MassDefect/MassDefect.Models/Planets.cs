using System.ComponentModel.DataAnnotations;

public class Planets
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public Stars Sun { get; set; }

    public SolarSystems SolarSystem { get; set; }
}