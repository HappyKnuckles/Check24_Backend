using Check24.Core.Entities;
using Check24.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Check24.Db.Repositories
{
    public class UserCommunityRepository : Repository<UserCommunity>, IUserCommunityRepository
    {

        public UserCommunityRepository(Check24Context context) : base(context) { }

        public async Task<List<UserCommunity>> ShowAllUserCommunities(Guid userId)
        {
            var allCommunities = await _context.UserCommunities.Where(x => x.User.UserId == userId).ToListAsync();
            return allCommunities;
        }
    }
}
