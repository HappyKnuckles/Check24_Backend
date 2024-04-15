using Check24.Core;
using Check24.Core.Entities;
using Check24.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Check24.Db.Repositories
{
    public class CommunityRepository : Repository<Community>, ICommunityRepository
    {

        public CommunityRepository(Check24Context context) : base(context) { }

        public async Task CreateCommunity(string communityName, User user)
        {
            Community community = new()
            {
                CommunityName = communityName.ToLower(),
            };
            await _context.AddAsync(community);
            await _context.SaveChangesAsync();
            await JoinCommunity(user, community);
        }

        public async Task JoinCommunity(User user, Community community)
        {
            if(user.UserCommunities.Count >= 5)
            {
                throw new CustomException("Too many communites");
            }
            if (user == null || community == null)
            {
                throw new CustomException("User or community cannot be null");
            }

            if (user.UserCommunities.Any(uc => uc.CommunityId == community.CommunityId))
            {
                throw new CustomException("User is already part of the community");
            }

            var userCommunity = new UserCommunity
            {
                User = user,
                Community = community
            };

            user.UserCommunities.Add(userCommunity);
            await GetCommunityPoints(community);
            await _context.SaveChangesAsync();
        }
        public async Task GetCommunityPoints(Community community)
        {
            var communityPoints = await _context.UserCommunities
                .Where(uc => uc.CommunityId == community.CommunityId)
                .SumAsync(uc => uc.User.Points ?? 0);

            community.CommunityPoints = communityPoints;
        }

        public async Task<List<User>> GetCommunityUserRanking(Community community)
        {
            var userRankings = await _context.UserCommunities
                .Where(uc => uc.CommunityId == community.CommunityId) // Filter users by community
                .Select(uc => uc.User)
                .OrderByDescending(u => u.Points) // Order users by points in descending order
                .ToListAsync();

            return userRankings;
        }

    }
}
