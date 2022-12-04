using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameGuidanceAPI.Migrations
{
    /// <inheritdoc />
    public partial class game3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "userFavorites",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summary",
                table: "userFavorites");
        }
    }
}
