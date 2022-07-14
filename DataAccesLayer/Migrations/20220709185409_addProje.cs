using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesLayer.Migrations
{
    public partial class addProje : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projes",
                columns: table => new
                {
                    ProjeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjeTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjeShort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjeContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjeLittlePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WriterID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projes", x => x.ProjeID);
                    table.ForeignKey(
                        name: "FK_Projes_Writers_WriterID",
                        column: x => x.WriterID,
                        principalTable: "Writers",
                        principalColumn: "WriterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projes_WriterID",
                table: "Projes",
                column: "WriterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projes");

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WriterID = table.Column<int>(type: "int", nullable: false),
                    ProjectContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectLittlePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectShort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projects", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_projects_Writers_WriterID",
                        column: x => x.WriterID,
                        principalTable: "Writers",
                        principalColumn: "WriterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_projects_WriterID",
                table: "projects",
                column: "WriterID");
        }
    }
}
