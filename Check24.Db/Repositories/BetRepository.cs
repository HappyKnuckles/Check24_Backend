using Check24.Core;
using Check24.Core.Entities;
using Check24.Core.Interfaces;
using Check24.Db;
using System.Runtime.InteropServices;

namespace Check24.Db.Repositories
{
    public class BetRepository : Repository<Bet>, IBetRepository
    {
        public BetRepository(Check24Context context) : base(context) { }

        public async Task PlaceBet(Game game, Bet bet, User user)
        {

            if (game == null || bet == null || user == null)
            {
                throw new CustomException("Game, Bet, or User cannot be null");
            }

            if (bet.User != null && bet.User.UserId != user.UserId)
            {
                throw new CustomException("User mismatch: The provided user does not match the user associated with the bet");
            }

            if (bet.Game != null && bet.Game.GameId != game.GameId)
            {
                throw new CustomException("Game mismatch: The provided game does not match the game associated with the bet");
            }

            bet.User = user;
            bet.Game = game;

            await _context.AddAsync(bet);
            await _context.SaveChangesAsync();
        }
    }
}
