using Check24.Core.Entities;
using Check24.Core.Interfaces;

namespace Check24.Db.Repositories
{
    public class UserCommunityRepository : Repository<UserCommunity>, IUserCommunityRepository
    {

        public UserCommunityRepository(Check24Context context) : base(context) { }
    }
}
