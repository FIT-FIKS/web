using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiks.Migrations
{
    public partial class AddRoundSeasonRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeasonID",
                table: "Round",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Round_SeasonID",
                table: "Round",
                column: "SeasonID");

            migrationBuilder.AddForeignKey(
                name: "FK_Round_Season_SeasonID",
                table: "Round",
                column: "SeasonID",
                principalTable: "Season",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Round_Season_SeasonID",
                table: "Round");

            migrationBuilder.DropIndex(
                name: "IX_Round_SeasonID",
                table: "Round");

            migrationBuilder.DropColumn(
                name: "SeasonID",
                table: "Round");
        }
    }
}
