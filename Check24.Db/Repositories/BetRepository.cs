using Check24.Core.Entities;
using Check24.Core.Interfaces;

namespace Check24.Db.Repositories
{
    public class BetRepository : Repository<Bet>, IBetRepository
    {
        public BetRepository(Check24Context context) : base(context) { }
    }
}
