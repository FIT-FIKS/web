using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiks.Migrations
{
    public partial class AddUserSchoolRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "schoolId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_schoolId",
                table: "User",
                column: "schoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_School_schoolId",
                table: "User",
                column: "schoolId",
                principalTable: "School",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_School_schoolId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_schoolId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "schoolId",
                table: "User");
        }
    }
}
