using Check24.Core.Entities;
using Check24.Core.Interfaces;

namespace Check24.Db.Repositories
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        public GameRepository(Check24Context context) : base(context) { }
    }
}
