using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiks.Migrations
{
    public partial class AddSubmissionTaskRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "Submission",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Submission_TaskId",
                table: "Submission",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Submission_Task_TaskId",
                table: "Submission",
                column: "TaskId",
                principalTable: "Task",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Submission_Task_TaskId",
                table: "Submission");

            migrationBuilder.DropIndex(
                name: "IX_Submission_TaskId",
                table: "Submission");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Submission");
        }
    }
}
