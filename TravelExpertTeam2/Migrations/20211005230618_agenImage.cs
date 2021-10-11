using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelExpertTeam2.Migrations
{
    public partial class agenImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgenImage",
                table: "Agencies",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgenImage",
                table: "Agencies");
        }
    }
}
