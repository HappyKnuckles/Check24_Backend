using Check24.Core.dtos;
using Check24.Core.Entities;

namespace Check24.Core.Interfaces
{
    public interface IUserCommunityRepository : IRepository<UserCommunity>
    {
        Task<List<CommunityMembersDto>> GetUserCommunitiesWithOtherUsers(Guid userId);
    }
}
