using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiks.Migrations
{
    public partial class AddTaskRoundRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoundId",
                table: "Task",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Task_RoundId",
                table: "Task",
                column: "RoundId");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Round_RoundId",
                table: "Task",
                column: "RoundId",
                principalTable: "Round",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Round_RoundId",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_RoundId",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "RoundId",
                table: "Task");
        }
    }
}
