using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebMidterm.Migrations
{
    /// <inheritdoc />
    public partial class initial04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "MovieType",
                table: "Movies",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieType",
                table: "Movies");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Movies",
                type: "varchar(30)",
                nullable: true);
        }
    }
}
