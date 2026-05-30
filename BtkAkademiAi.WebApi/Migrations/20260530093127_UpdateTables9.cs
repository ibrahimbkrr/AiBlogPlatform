using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BtkAkademiAi.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTables9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SliderCategoryImageUrl",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SliderCategoryImageUrl",
                table: "Articles");
        }
    }
}
