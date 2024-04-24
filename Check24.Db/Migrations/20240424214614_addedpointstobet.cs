using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Check24.Db.Migrations
{
    /// <inheritdoc />
    public partial class addedpointstobet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BetPoints",
                table: "Bets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BetPoints",
                table: "Bets");
        }
    }
}
