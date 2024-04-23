using Check24.Core.Entities;
using Check24.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Check24.Db.Repositories
{
    public class GameRepository : Repository<Game>, IGameRepository
    {

        public GameRepository(Check24Context context) : base(context) { 
        }

        public async Task<List<Game>> GetGamesWithoutBet(Guid userId)
        {
            var gamesWithoutBets = await _context.Games
                    .Where(g => !g.Bets.Any(b => b.UserId == userId))
                    .ToListAsync();

            return gamesWithoutBets;
        }

        public async Task SetGoal(bool teamAway, int gameId)
        {
            var game = await _context.Games.FindAsync(gameId);
            if (teamAway)
            {
                game.TeamAwayGoals++;
            } else game.TeamHomeGoals++;

            await _context.SaveChangesAsync();
        }
    }
}
