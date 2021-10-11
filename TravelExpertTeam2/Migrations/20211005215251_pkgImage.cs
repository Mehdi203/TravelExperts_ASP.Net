using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelExpertTeam2.Migrations
{
    public partial class pkgImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PkgImage",
                table: "Packages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PkgImage",
                table: "Packages");
        }
    }
}
