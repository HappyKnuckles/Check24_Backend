using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Check24.Db.Migrations
{
    /// <inheritdoc />
    public partial class changedpk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Communities",
                columns: table => new
                {
                    CommunityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommunityName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Communit__CCAA5B69291F2E5F", x => x.CommunityId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HomeTeam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AwayTeam = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GameDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    GameStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Games__2AB897FDE4264D3A", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Points = table.Column<int>(type: "int", nullable: true),
                    RegistrationDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__1788CC4CEE4C52B1", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Bets",
                columns: table => new
                {
                    BetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GameId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HomeTeamGoals = table.Column<int>(type: "int", nullable: true),
                    AwayTeamGoals = table.Column<int>(type: "int", nullable: true),
                    BetTimestamp = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Bets__454024890E793E80", x => x.BetId);
                    table.ForeignKey(
                        name: "FK__Bets__GameId__70DDC3D8",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId");
                    table.ForeignKey(
                        name: "FK__Bets__UserId__6FE99F9F",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "UserCommunities",
                columns: table => new
                {
                    UserCommunityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CommunityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserComm__3781934CA42845C8", x => x.UserCommunityId);
                    table.ForeignKey(
                        name: "FK__UserCommu__Commu__619B8048",
                        column: x => x.CommunityId,
                        principalTable: "Communities",
                        principalColumn: "CommunityId");
                    table.ForeignKey(
                        name: "FK__UserCommu__UserI__60A75C0F",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bets_GameId",
                table: "Bets",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_UserId",
                table: "Bets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCommunities_CommunityId",
                table: "UserCommunities",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCommunities_UserId",
                table: "UserCommunities",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bets");

            migrationBuilder.DropTable(
                name: "UserCommunities");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Communities");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
