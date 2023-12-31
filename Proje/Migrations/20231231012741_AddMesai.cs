using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje.Migrations
{
    public partial class AddMesai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mesai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoktorId = table.Column<int>(type: "int", nullable: false),
                    BaslangicZamani = table.Column<TimeSpan>(type: "time", nullable: false),
                    BitisZamani = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesai", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mesai_Doktor_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "Doktor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MesaiGunu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MesaiId = table.Column<int>(type: "int", nullable: true),
                    Gun = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MesaiGunu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MesaiGunu_Mesai_MesaiId",
                        column: x => x.MesaiId,
                        principalTable: "Mesai",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mesai_DoktorId",
                table: "Mesai",
                column: "DoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_MesaiGunu_MesaiId",
                table: "MesaiGunu",
                column: "MesaiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MesaiGunu");

            migrationBuilder.DropTable(
                name: "Mesai");
        }
    }
}
