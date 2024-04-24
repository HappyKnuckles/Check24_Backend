using Check24.Core.Entities;

namespace Check24.Core.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> Login(string userName);
        Task<User> GetUserRank(string userName);
        Task<List<User>> GetLeaderboard();
    }
}
