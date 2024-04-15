using Check24.Core.Entities;

namespace Check24.Core.Interfaces
{
    public interface IUserCommunityRepository : IRepository<UserCommunity>
    {
        Task<List<UserCommunity>> ShowAllUserCommunities(Guid userId);
    }
}
