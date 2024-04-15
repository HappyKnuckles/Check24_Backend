using Check24.Core.Entities;

namespace Check24.Core.Interfaces
{
    public interface IBetRepository : IRepository<Bet>
    {
        Task PlaceBet(Game game, Bet bet, User user);
    }
}
