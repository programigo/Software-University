using System.ComponentModel.DataAnnotations;

public class Stars
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public SolarSystems SolarSystem { get; set; }
}