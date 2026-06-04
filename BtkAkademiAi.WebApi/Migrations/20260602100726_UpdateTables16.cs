using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BtkAkademiAi.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "TradingVideos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TradingVideos_AppUserId",
                table: "TradingVideos",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TradingVideos_AspNetUsers_AppUserId",
                table: "TradingVideos",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TradingVideos_AspNetUsers_AppUserId",
                table: "TradingVideos");

            migrationBuilder.DropIndex(
                name: "IX_TradingVideos_AppUserId",
                table: "TradingVideos");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "TradingVideos");
        }
    }
}
