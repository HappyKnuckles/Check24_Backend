using Check24.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check24.Core.Dtos
{
    public class GameBetDto
    {
        public BetDto Bet { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
    }
}
