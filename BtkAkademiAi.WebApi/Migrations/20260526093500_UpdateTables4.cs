using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BtkAkademiAi.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFeatureSlider",
                table: "Articles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFeatureSlider",
                table: "Articles");
        }
    }
}
