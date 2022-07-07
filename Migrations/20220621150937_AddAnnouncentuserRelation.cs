using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiks.Migrations
{
    public partial class AddAnnouncentuserRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AutorId",
                table: "Announcement",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Announcement_AutorId",
                table: "Announcement",
                column: "AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcement_User_AutorId",
                table: "Announcement",
                column: "AutorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcement_User_AutorId",
                table: "Announcement");

            migrationBuilder.DropIndex(
                name: "IX_Announcement_AutorId",
                table: "Announcement");

            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "Announcement");
        }
    }
}
