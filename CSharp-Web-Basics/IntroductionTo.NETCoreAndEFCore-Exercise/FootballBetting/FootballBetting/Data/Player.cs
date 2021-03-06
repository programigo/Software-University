﻿using System.Collections.Generic;

public class Player
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int SquadNumber { get; set; }

    public int TeamId { get; set; }

    public Team Team { get; set; }

    public string PositionId { get; set; }

    public Position Position { get; set; }

    public bool IsInjured { get; set; }

    public List<PlayerGame> Games { get; set; } = new List<PlayerGame>();
}