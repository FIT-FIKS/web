using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiks.Migrations
{
    public partial class AddCorectionModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Correction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Feedback = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    AutorId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Correction", x => x.Id);
                    table.CheckConstraint("CorrectionScoreCheckConstraintLOE100", "Score <= 100");
                    table.CheckConstraint("CorrectionScoreCheckConstraintMOE0", "Score >= 0");
                    table.ForeignKey(
                        name: "FK_Correction_User_AutorId",
                        column: x => x.AutorId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Correction_AutorId",
                table: "Correction",
                column: "AutorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Correction");
        }
    }
}
