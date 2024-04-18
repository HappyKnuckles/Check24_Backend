using Check24.Core.dtos;
using Check24.Core.Entities;
using Check24.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Check24.Db.Repositories
{
    public class UserCommunityRepository : Repository<UserCommunity>, IUserCommunityRepository
    {

        public UserCommunityRepository(Check24Context context) : base(context) { }

        public async Task<List<CommunityMembersDto>> GetUserCommunitiesWithOtherUsers(Guid userId)
        {
            var userCommunities = await _context.UserCommunities
                .Where(uc => uc.UserId == userId)
                .Select(uc => uc.CommunityId)
                .Distinct()
                .ToListAsync();

            var communityMembers = new List<CommunityMembersDto>();

            foreach (var communityId in userCommunities)
            {
                var community = await _context.Communities
                    .Where(c => c.CommunityId == communityId)
                    .FirstOrDefaultAsync();

                var members = await _context.UserCommunities
                    .Where(uc => uc.CommunityId == communityId)
                    .Select(uc => uc.User)
                    .ToListAsync();

                communityMembers.Add(new CommunityMembersDto
                {
                    CommunityId = community!.CommunityId,
                    CommunityName = community.CommunityName, 
                    Members = members!
                });
            }

            return communityMembers;
        }


    }
}
