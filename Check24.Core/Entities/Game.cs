using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Check24.Core.Entities;

public partial class Game
{
    public string TeamHomeName { get; set; } = null!;

    public string TeamAwayName { get; set; } = null!;

    public DateTime GameStartsAt { get; set; }
    public int? TeamAwayGoals { get; set; }
    public int? TeamHomeGoals { get; set; }

    [Key]
    public int GameId { get; set; }

    public string? GameStatus { get; set; }
    public virtual ICollection<Bet> Bets { get; set; } = new List<Bet>();

}
