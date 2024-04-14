using Check24.Core.Entities;
using Check24.Core.Interfaces;

namespace Check24.Db.Repositories
{
    public class CommunityRepository : Repository<Community>, ICommunityRepository
    {

        public CommunityRepository(Check24Context context) : base(context) { }

        public async Task CreateCommunity(string communityName)
        {
            Community community = new()
            {
                CommunityName = communityName.ToLower(),
            };
            await _context.AddAsync(community);
            await _context.SaveChangesAsync();
        }

        public async Task JoinCommunity(User user, Community community)
        {
            if (user == null || community == null)
            {
                throw new ArgumentException("User or community cannot be null");
            }

            if (user.UserCommunities.Any(uc => uc.CommunityId == community.CommunityId))
            {
                throw new InvalidOperationException("User is already part of the community");
            }

            var userCommunity = new UserCommunity
            {
                User = user,
                Community = community
            };

            user.UserCommunities.Add(userCommunity);

            await _context.SaveChangesAsync();
        }

    }
}
