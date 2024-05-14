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

        public async Task CreateAndJoinCommunity(Guid userId, string communityName)
        {
            Community newCommunity = new()
            {
                CommunityId = new Guid(),
                CommunityName = communityName,
                CommunityPoints = 0,
            };
            await _context.AddAsync(newCommunity);
            await _context.SaveChangesAsync();
            await JoinCommunity(userId, newCommunity.CommunityId);

        }
        public async Task<List<Community>> GetAllCommunitiesWithoutUser(Guid userId)
        {
            var userCommunityIds = await _context.UserCommunities
                .Where(uc => uc.UserId == userId)
                .Select(uc => uc.CommunityId)
                .ToListAsync();

            var communitiesWithoutUser = await _context.Communities
                .Where(c => !userCommunityIds.Contains(c.CommunityId))
                .ToListAsync();

            return communitiesWithoutUser;
        }

        public async Task JoinCommunity(Guid userId, Guid communityId)
        {
            var user = _context.Users.Where(u => u.UserId == userId).FirstOrDefault();
            var community = _context.Communities.Where(c => c.CommunityId == communityId).FirstOrDefault();
            if (user == null || community == null)
            {
                throw new CustomException("User or community cannot be null");
            }
            if (user.CommunityCount >= 5)
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
            user.CommunityCount++;
            await _context.SaveChangesAsync();            
            await SetCommunityPoints(community.CommunityId);
        }
        
        public async Task LeaveCommunity(Guid userId, Guid communityId)
        {
            var user = _context.Users.Where(u => u.UserId == userId).FirstOrDefault();
            var community = _context.Communities.Where(c => c.CommunityId == communityId).FirstOrDefault();
            var userCommunity = await _context.UserCommunities.Where(uc => uc.UserId == userId && uc.CommunityId == communityId).FirstOrDefaultAsync();

            user.UserCommunities.Remove(userCommunity);
            user.CommunityCount--;
            await _context.SaveChangesAsync();
            await SetCommunityPoints(community.CommunityId);
        }

        public async Task SetCommunityPoints(Guid communityId)
        {
            var communityPoints = await _context.UserCommunities
                .Where(uc => uc.CommunityId == communityId)
                .SumAsync(uc => uc.User!.Points ?? 0);

            var community = await _context.Communities.FindAsync(communityId);

            community!.CommunityPoints = communityPoints;
            await _context.SaveChangesAsync();
        }

        public async Task SetAllCommunityPoints()
        {
            var allCommunities = await _context.Communities.ToListAsync();
            foreach (var community in allCommunities)
            {
                await SetCommunityPoints(community.CommunityId);
            }
        }

        public async Task<CommunityMembersDto> GetCommunityUserRanking(Guid? communityId)
        {
            if (communityId == null || communityId == Guid.Empty)
            {
                var userList = await _context.Users
                    .OrderByDescending(u => u.Points)
                    .ThenBy(u => u.RegistrationDate)
                    .ToListAsync();

                var members = userList.Select(user => new UserDto
                {
                    Points = user.Points,
                    Name = user.Username,
                    RegistrationDate = user.RegistrationDate
                }).ToList();

                var communityMembers = new CommunityMembersDto
                {
                    Members = members,
                    CommunityName = "",
                    CommunityPoints = 0
                };

                return communityMembers;
            }
            else
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

                var communityMembers = new CommunityMembersDto
                {
                    Members = members,
                    CommunityName = community.CommunityName,
                    CommunityPoints = community.CommunityPoints
                };

                return communityMembers;
            }
        }


    }
}
