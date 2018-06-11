using Microsoft.EntityFrameworkCore.Migrations;

namespace ExperienceTracker.Migrations
{
    public partial class RemoveCampaignPlayerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "CampaignPlayer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CampaignPlayer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
