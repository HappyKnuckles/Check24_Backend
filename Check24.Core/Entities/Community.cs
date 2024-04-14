using Check24.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Check24.Core.Entities;

public partial class Community
{
    [Key]
    public Guid CommunityId { get; set; }

    public string CommunityName { get; set; } = null!;

    public List<UserCommunity> UserCommunities { get; set; }
}
