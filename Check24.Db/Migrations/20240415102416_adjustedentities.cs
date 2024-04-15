using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Check24.Db.Migrations
{
    /// <inheritdoc />
    public partial class adjustedentities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsBettable",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                name: "Rank",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsBettable",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "CommunityPoints",
                table: "Communities");
        }
    }
}
