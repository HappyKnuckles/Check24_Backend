using System;
using System.Collections.Generic;

namespace Check24.Core.Entities
{

    public partial class Community
    {
        public Guid CommunityId { get; set; }

        public string CommunityName { get; set; } = null!;

        public virtual ICollection<UserCommunity> UserCommunities { get; set; } = new List<UserCommunity>();
    }
}