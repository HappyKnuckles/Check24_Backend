using Check24.Core.Dtos;
using Check24.Core.Entities;

namespace Check24.Core.Interfaces
{
    public interface IBetRepository : IRepository<Bet>
    {
        Task PlaceBet(int homeGoals, int awayGoals, int gameId, Guid userId);
        Task<List<GameBetDto>> GetUserBets(Guid userId);

    }
}
