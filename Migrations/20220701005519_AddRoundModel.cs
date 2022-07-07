using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fiks.Migrations
{
    public partial class AddRoundModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Round",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descrption = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    OpenFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OpenTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Penaliazation = table.Column<int>(type: "int", nullable: false),
                    PenalizationStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Round", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Round");
        }
    }
}
