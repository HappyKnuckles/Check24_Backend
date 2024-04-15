using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Check24.Db.Migrations
{
    /// <inheritdoc />
    public partial class addedgoals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamAwayGoals",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TeamHomeGoals",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommunityPoints",
                table: "Communities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamAwayGoals",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "TeamHomeGoals",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CommunityPoints",
                table: "Communities");
        }
    }
}
