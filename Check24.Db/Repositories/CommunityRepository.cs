using Check24.Core;
using Check24.Core.dtos;
using Check24.Core.Dtos;
using Check24.Core.Entities;
using Check24.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Check24.Db.Repositories
{
    public class CommunityRepository : Repository<Community>, ICommunityRepository
    {

        public CommunityRepository(Check24Context context) : base(context) { }

        public async Task JoinCommunity(Guid userId, Guid communityId)
        {
            var user = _context.Users.Where(u => u.UserId == userId).FirstOrDefault();
            var community = _context.Communities.Where(c => c.CommunityId == communityId).FirstOrDefault();
            if (user == null || community == null)
            {
                throw new CustomException("User or community cannot be null");
            }
            if (user.UserCommunities.Count >= 5)
            {
                throw new CustomException("Too many communites");
            }
            if (user.UserCommunities.Any(uc => uc.CommunityId == community.CommunityId))
            {
                throw new CustomException("User is already part of the community");
            }

            var userCommunity = new UserCommunity
            {
                User = user,
                Community = community,
                UserCommunityId = new Guid()
            };

            user.UserCommunities.Add(userCommunity);
            await SetCommunityPoints(community);
            await _context.SaveChangesAsync();
        }
        public async Task SetCommunityPoints(Community community)
        {
            var communityPoints = await _context.UserCommunities
                .Where(uc => uc.CommunityId == community.CommunityId)
                .SumAsync(uc => uc.User!.Points ?? 0);

            community.CommunityPoints = communityPoints;
        }

        public async Task<CommunityMembersDto> GetCommunityUserRanking(Guid communityId)
        {
            var community = await _context.Communities.FindAsync(communityId);

            var userCommunities = await _context.UserCommunities
               .Where(uc => uc.CommunityId == communityId)
               .ToListAsync();
         
            var userList = await _context.Users
                    .Where(u => userCommunities.Select(uc => uc.UserId).Contains(u.UserId))
                    .OrderByDescending(u => u.Points)
                    .ThenBy(u => u.RegistrationDate)
                    .ToListAsync();

            var members = userList.Select(user => new UserDto
            {
                Points = user.Points,
                Name = user.Username,
                RegistrationDate = user.RegistrationDate
            }).ToList();

            var communityMembers =new CommunityMembersDto
            {
                Members = members,
                CommunityName = community.CommunityName,
                CommunityPoints = community.CommunityPoints
            };

            return communityMembers!;
        }

    }
}
