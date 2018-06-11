using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExperienceTracker.Migrations
{
    public partial class AddedCharacters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Campaigns_CampaignId",
                table: "Players");

            migrationBuilder.DropTable(
                name: "PlayerEncounter");

            migrationBuilder.DropIndex(
                name: "IX_Players_CampaignId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                table: "Players");

            migrationBuilder.CreateTable(
                name: "CampaignPlayer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false),
                    CampaignId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignPlayer", x => new { x.PlayerId, x.CampaignId });
                    table.ForeignKey(
                        name: "FK_CampaignPlayer_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignPlayer_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CampaignId = table.Column<int>(nullable: false),
                    PlayerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Character_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Character_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterEncounter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    CharacterId = table.Column<int>(nullable: false),
                    EncounterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterEncounter", x => new { x.CharacterId, x.EncounterId });
                    table.ForeignKey(
                        name: "FK_CharacterEncounter_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterEncounter_Encounters_EncounterId",
                        column: x => x.EncounterId,
                        principalTable: "Encounters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignPlayer_CampaignId",
                table: "CampaignPlayer",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_CampaignId",
                table: "Character",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_PlayerId",
                table: "Character",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterEncounter_EncounterId",
                table: "CharacterEncounter",
                column: "EncounterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignPlayer");

            migrationBuilder.DropTable(
                name: "CharacterEncounter");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.AddColumn<int>(
                name: "CampaignId",
                table: "Players",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PlayerEncounter",
                columns: table => new
                {
                    PlayerId = table.Column<int>(nullable: false),
                    EncounterId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerEncounter", x => new { x.PlayerId, x.EncounterId });
                    table.ForeignKey(
                        name: "FK_PlayerEncounter_Encounters_EncounterId",
                        column: x => x.EncounterId,
                        principalTable: "Encounters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerEncounter_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Players_CampaignId",
                table: "Players",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerEncounter_EncounterId",
                table: "PlayerEncounter",
                column: "EncounterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Campaigns_CampaignId",
                table: "Players",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
