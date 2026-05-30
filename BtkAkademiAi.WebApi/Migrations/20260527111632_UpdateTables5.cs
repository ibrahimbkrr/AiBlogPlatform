using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BtkAkademiAi.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FeatureSliderImageUrl",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeatureSliderImageUrl",
                table: "Articles");
        }
    }
}
