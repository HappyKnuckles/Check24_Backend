using System;
using System.Collections.Generic;

namespace Check24.Core.Entities
{

    public partial class Game
    {
        public Guid GameId { get; set; }

        public string HomeTeam { get; set; } = null!;

        public string AwayTeam { get; set; } = null!;

        public DateTime? GameDateTime { get; set; }

        public string? GameStatus { get; set; }

        public virtual ICollection<Bet> Bets { get; set; } = new List<Bet>();
    }
}