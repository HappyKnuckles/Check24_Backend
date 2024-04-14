using System;
using System.Collections.Generic;
using Check24.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Check24.Db;

public partial class Check24Context : DbContext
{
    public Check24Context()
    {
    }

    public Check24Context(DbContextOptions<Check24Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Bet> Bets { get; set; }

    public virtual DbSet<Community> Communities { get; set; }

    public virtual DbSet<Game> Games { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserCommunity> UserCommunities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserCommunity>()
                 .HasKey(uc => new { uc.UserId, uc.CommunityId });

        modelBuilder.Entity<UserCommunity>()
            .HasOne(uc => uc.User)
            .WithMany(u => u.UserCommunities)
            .HasForeignKey(uc => uc.UserId);

        modelBuilder.Entity<UserCommunity>()
            .HasOne(uc => uc.Community)
            .WithMany(c => c.UserCommunities)
            .HasForeignKey(uc => uc.CommunityId);

        modelBuilder.Entity<Bet>()
            .HasOne(b => b.User)
            .WithMany(u => u.Bets)
            .HasForeignKey(b => b.UserId);

        modelBuilder.Entity<Bet>()
            .HasOne(b => b.Game)
            .WithMany(g => g.Bets)
            .HasForeignKey(b => b.GameId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.UserCommunities)
            .WithOne(uc => uc.User)
            .HasForeignKey(uc => uc.UserId);

        modelBuilder.Entity<Game>()
            .HasMany(g => g.Bets)
            .WithOne(b => b.Game)
            .HasForeignKey(b => b.GameId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }

}
