using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiks.Migrations
{
    public partial class AddSubmissionRelationToCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubmissionId",
                table: "Correction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Correction_SubmissionId",
                table: "Correction",
                column: "SubmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Correction_Submission_SubmissionId",
                table: "Correction",
                column: "SubmissionId",
                principalTable: "Submission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Correction_Submission_SubmissionId",
                table: "Correction");

            migrationBuilder.DropIndex(
                name: "IX_Correction_SubmissionId",
                table: "Correction");

            migrationBuilder.DropColumn(
                name: "SubmissionId",
                table: "Correction");
        }
    }
}
