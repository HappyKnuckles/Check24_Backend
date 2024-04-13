using Check24.Core.Entities;
using System;
using System.Collections.Generic;

namespace Check24.Core.Entities
{

    public partial class UserCommunity
    {
        public Guid UserCommunityId { get; set; }

        public Guid? UserId { get; set; }

        public Guid? CommunityId { get; set; }

        public virtual Community? Community { get; set; }

        public virtual User? User { get; set; }
    }
}