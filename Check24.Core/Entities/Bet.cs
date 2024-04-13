using System;
using System.Collections.Generic;

namespace Check24.Core.Entities
{

    public partial class Bet
    {
        public Guid BetId { get; set; }

        public Guid? UserId { get; set; }

        public Guid? GameId { get; set; }

        public int? HomeTeamGoals { get; set; }

        public int? AwayTeamGoals { get; set; }

        public DateTime? BetTimestamp { get; set; }

        public virtual Game? Game { get; set; }

        public virtual User? User { get; set; }
    }
}