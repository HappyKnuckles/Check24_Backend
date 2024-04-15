using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Check24.Core.Entities;

public partial class Bet
{
    [Key]
    public Guid BetId { get; set; }

    [ForeignKey("User")]
    public Guid UserId { get; set; }

    [ForeignKey("Game")]
    public int GameId { get; set; }

    public int? HomeTeamGoals { get; set; }

    public int? AwayTeamGoals { get; set; }

    public DateTime? BetTimestamp { get; set; }

    public User User { get; set; }

    public Game Game { get; set; }

}
