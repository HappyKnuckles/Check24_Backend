using Check24.Core.Entities;

namespace Check24.Core.Interfaces
{
    public interface IGameRepository : IRepository<Game>
    {
        Task<List<Game>> GetGamesWithoutBet(Guid userId);
        Task SetGoal(bool teamAway, int gameId);
    }
}
