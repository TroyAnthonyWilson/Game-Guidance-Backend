using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameGuidanceAPI.Migrations
{
    /// <inheritdoc />
    public partial class game2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userFavorites_games_GameId",
                table: "userFavorites");

            migrationBuilder.DropForeignKey(
                name: "FK_userFavorites_users_UserId",
                table: "userFavorites");

            migrationBuilder.DropIndex(
                name: "IX_userFavorites_GameId",
                table: "userFavorites");

            migrationBuilder.DropIndex(
                name: "IX_userFavorites_UserId",
                table: "userFavorites");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_userFavorites_GameId",
                table: "userFavorites",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_userFavorites_UserId",
                table: "userFavorites",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_userFavorites_games_GameId",
                table: "userFavorites",
                column: "GameId",
                principalTable: "games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_userFavorites_users_UserId",
                table: "userFavorites",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
