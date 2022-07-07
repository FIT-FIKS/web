using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiks.Migrations
{
    public partial class AddScriptTasksRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "Script",
                newName: "ScriptType");

            migrationBuilder.AddColumn<int>(
                name: "Script1Id",
                table: "Task",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Script2Id",
                table: "Task",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Task_Script1Id",
                table: "Task",
                column: "Script1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Task_Script2Id",
                table: "Task",
                column: "Script2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Script_Script1Id",
                table: "Task",
                column: "Script1Id",
                principalTable: "Script",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Script_Script2Id",
                table: "Task",
                column: "Script2Id",
                principalTable: "Script",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Script_Script1Id",
                table: "Task");

            migrationBuilder.DropForeignKey(
                name: "FK_Task_Script_Script2Id",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_Script1Id",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_Script2Id",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Script1Id",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Script2Id",
                table: "Task");

            migrationBuilder.RenameColumn(
                name: "ScriptType",
                table: "Script",
                newName: "MyProperty");
        }
    }
}
