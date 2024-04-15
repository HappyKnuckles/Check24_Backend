using Check24.Core.Entities;
using Check24.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Check24.Db.Repositories
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(Check24Context context) : base(context) { }


        public async Task DeactivateBets()
        {
            var allGames = await _context.Games.ToListAsync();
            foreach (var game in allGames)
            {
                if(game.GameStartsAt < DateTime.UtcNow)
                {
                    game.IsBettable = false;
                }
            }
            await _context.SaveChangesAsync();
        }


    }
}
