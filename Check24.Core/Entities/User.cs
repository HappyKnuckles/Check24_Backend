using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Check24.Core.Entities;

public partial class User
{
    [Key]
    public Guid UserId { get; set; }

    public string Username { get; set; } = null!;

    public int? Points { get; set; }

    public DateTime RegistrationDate { get; set; }

    public virtual ICollection<Bet> Bets { get; set; } = new List<Bet>();

    public virtual ICollection<UserCommunity> UserCommunities { get; set; } = new List<UserCommunity>();
}
