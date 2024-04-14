using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Check24.Core.Entities;

public partial class UserCommunity
{
    [Key]
    public Guid UserCommunityId { get; set; }

    [ForeignKey("User")]
    public Guid? UserId { get; set; }

    [ForeignKey("Community")]
    public Guid? CommunityId { get; set; }

    public Community? Community { get; set; }

    public User? User { get; set; }
}
