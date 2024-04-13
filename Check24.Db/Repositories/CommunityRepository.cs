using Check24.Core.Entities;
using Check24.Core.Interfaces;

namespace Check24.Db.Repositories
{
    public class CommunityRepository : Repository<Community>, ICommunityRepository
    {

        public CommunityRepository(Check24Context context) : base(context) { }
    }
}
