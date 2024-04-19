using Check24.Core.dtos;
using Check24.Core.Entities;

namespace Check24.Core.Interfaces
{
    public interface ICommunityRepository : IRepository<Community>
    {
        Task JoinCommunity(Guid userId, Guid communityId);
        Task SetCommunityPoints(Community community);
        Task<CommunityMembersDto> GetCommunityUserRanking(Guid communityId);
    }
}
