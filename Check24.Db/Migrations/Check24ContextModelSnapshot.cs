﻿// <auto-generated />
using System;
using Check24.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Check24.Db.Migrations
{
    [DbContext(typeof(Check24Context))]
    partial class Check24ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Check24.Core.Entities.Bet", b =>
                {
                    b.Property<Guid>("BetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AwayTeamGoals")
                        .HasColumnType("int");

                    b.Property<int>("BetPoints")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BetTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int?>("HomeTeamGoals")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BetId");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("Bets");
                });

            modelBuilder.Entity("Check24.Core.Entities.Community", b =>
                {
                    b.Property<Guid>("CommunityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CommunityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CommunityPoints")
                        .HasColumnType("int");

                    b.HasKey("CommunityId");

                    b.ToTable("Communities");
                });

            modelBuilder.Entity("Check24.Core.Entities.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameId"));

                    b.Property<DateTime>("GameStartsAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("GameStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamAwayGoals")
                        .HasColumnType("int");

                    b.Property<string>("TeamAwayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamHomeGoals")
                        .HasColumnType("int");

                    b.Property<string>("TeamHomeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GameId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Check24.Core.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CommunityCount")
                        .HasColumnType("int");

                    b.Property<int?>("Points")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Check24.Core.Entities.UserCommunity", b =>
                {
                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CommunityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserCommunityId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "CommunityId");

                    b.HasIndex("CommunityId");

                    b.ToTable("UserCommunities");
                });

            modelBuilder.Entity("Check24.Core.Entities.Bet", b =>
                {
                    b.HasOne("Check24.Core.Entities.Game", "Game")
                        .WithMany("Bets")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Check24.Core.Entities.User", "User")
                        .WithMany("Bets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Check24.Core.Entities.UserCommunity", b =>
                {
                    b.HasOne("Check24.Core.Entities.Community", "Community")
                        .WithMany("UserCommunities")
                        .HasForeignKey("CommunityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Check24.Core.Entities.User", "User")
                        .WithMany("UserCommunities")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Community");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Check24.Core.Entities.Community", b =>
                {
                    b.Navigation("UserCommunities");
                });

            modelBuilder.Entity("Check24.Core.Entities.Game", b =>
                {
                    b.Navigation("Bets");
                });

            modelBuilder.Entity("Check24.Core.Entities.User", b =>
                {
                    b.Navigation("Bets");

                    b.Navigation("UserCommunities");
                });
#pragma warning restore 612, 618
        }
    }
}
