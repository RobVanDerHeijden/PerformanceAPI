using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Winrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Losses",
                table: "PlayerChampions");

            migrationBuilder.DropColumn(
                name: "Wins",
                table: "PlayerChampions");

            migrationBuilder.AddColumn<float>(
                name: "WinRate",
                table: "PlayerChampions",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WinRate",
                table: "PlayerChampions");

            migrationBuilder.AddColumn<int>(
                name: "Losses",
                table: "PlayerChampions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Wins",
                table: "PlayerChampions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
