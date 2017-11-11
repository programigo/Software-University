using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Position
{
    [Key]
    public string Id { get; set; }

    public string PositionDescription { get; set; }

    public List<Player> Players { get; set; } = new List<Player>();
}