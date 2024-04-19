using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check24.Core.Dtos
{
    public class BetDto
    {
        public int? HomeTeamGoals { get; set; }

        public int? AwayTeamGoals { get; set; }

        public DateTime? BetTimestamp { get; set; }

    }
}
