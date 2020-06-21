using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class OnModelCreatingExpand : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerChampions",
                table: "PlayerChampions");

            migrationBuilder.DropIndex(
                name: "IX_PlayerChampions_PlayerId",
                table: "PlayerChampions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PlayerChampions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerChampions",
                table: "PlayerChampions",
                columns: new[] { "PlayerId", "ChampionId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlayerChampions",
                table: "PlayerChampions");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PlayerChampions",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlayerChampions",
                table: "PlayerChampions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerChampions_PlayerId",
                table: "PlayerChampions",
                column: "PlayerId");
        }
    }
}
