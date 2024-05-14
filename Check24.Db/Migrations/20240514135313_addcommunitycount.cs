using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Check24.Db.Migrations
{
    /// <inheritdoc />
    public partial class addcommunitycount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommunityCount",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommunityCount",
                table: "Users");
        }
    }
}
