using Check24.Core;
using Check24.Core.Entities;
using Check24.Core.Interfaces;
using Check24.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace Check24.Db.Repositories
{
    public class BetRepository : Repository<Bet>, IBetRepository
    {
        public BetRepository(Check24Context context) : base(context) { }

        public async Task PlaceBet(int homeGoals, int awayGoals, int gameId, Guid userId)
        {
            Bet bet = new()
            {
                BetId = Guid.NewGuid(),
                HomeTeamGoals = homeGoals,
                AwayTeamGoals = awayGoals,
                GameId = gameId,
                UserId = userId,
                BetTimestamp = DateTime.Now
            };

            var game = await _context.Games.FindAsync(gameId) ?? throw new InvalidOperationException("The specified game does not exist.");
            var user = await _context.Users.FindAsync(userId) ?? throw new InvalidOperationException("The specified user does not exist.");

            game.Bets.Add(bet);

            bet.Game = game;
            bet.User = user; 

            user.Bets.Add(bet);
            _context.Bets.Add(bet);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Bet>> GetUserBets(Guid userId)
        {
            var allBets = await _context.Bets.Where(b => b.UserId == userId).Include(b => b.Game).ToListAsync();
            return allBets;
        }
    }
}
