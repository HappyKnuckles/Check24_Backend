using System;
using Check24.Core.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Check24.Db
{
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Server=tcp:check24challenge.database.windows.net,1433;Initial Catalog=check24;Persist Security Info=False;User ID=happyknuckles;Password=05.Nico082001;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bet>(entity =>
            {
                entity.HasKey(e => e.BetId).HasName("PK__Bets__454024890E793E80");

                entity.Property(e => e.BetId).ValueGeneratedNever();
                entity.Property(e => e.BetTimestamp).HasColumnType("datetime");

                entity.HasOne(d => d.Game).WithMany(p => p.Bets)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK__Bets__GameId__70DDC3D8");

                entity.HasOne(d => d.User).WithMany(p => p.Bets)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Bets__UserId__6FE99F9F");
            });

            modelBuilder.Entity<Community>(entity =>
            {
                entity.HasKey(e => e.CommunityId).HasName("PK__Communit__CCAA5B69291F2E5F");

                entity.Property(e => e.CommunityId).ValueGeneratedNever();
                entity.Property(e => e.CommunityName).HasMaxLength(50);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.GameId).HasName("PK__Games__2AB897FDE4264D3A");

                entity.Property(e => e.GameId).ValueGeneratedNever();
                entity.Property(e => e.AwayTeam).HasMaxLength(50);
                entity.Property(e => e.GameDateTime).HasColumnType("datetime");
                entity.Property(e => e.GameStatus).HasMaxLength(50);
                entity.Property(e => e.HomeTeam).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CEE4C52B1");

                entity.Property(e => e.UserId).ValueGeneratedNever();
                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<UserCommunity>(entity =>
            {
                entity.HasKey(e => e.UserCommunityId).HasName("PK__UserComm__3781934CA42845C8");

                entity.Property(e => e.UserCommunityId).ValueGeneratedNever();

                entity.HasOne(d => d.Community).WithMany(p => p.UserCommunities)
                    .HasForeignKey(d => d.CommunityId)
                    .HasConstraintName("FK__UserCommu__Commu__619B8048");

                entity.HasOne(d => d.User).WithMany(p => p.UserCommunities)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserCommu__UserI__60A75C0F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}