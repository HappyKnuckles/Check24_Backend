﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Check24.Core.Entities;

public partial class Game
{
    public string TeamHomeName { get; set; } = null!;

    public string TeamAwayName { get; set; } = null!;

    public DateTime GameStartsAt { get; set; }

    [Key]
    public int GameId { get; set; }
    public bool IsBettable { get; set; } = true;

    public string? GameStatus { get; set; }
    public List<Bet> Bets { get; set; }

}
