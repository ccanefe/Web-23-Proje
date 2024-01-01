using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje.Migrations
{
    public partial class AddMesai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MesaiId",
                table: "MesaiGunu",
                type: "int",
                nullable: true);

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
                        name: "FK_Mesai_Doktors_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "Doktors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MesaiGunu_MesaiId",
                table: "MesaiGunu",
                column: "MesaiId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesai_DoktorId",
                table: "Mesai",
                column: "DoktorId");

            migrationBuilder.AddForeignKey(
                name: "FK_MesaiGunu_Mesai_MesaiId",
                table: "MesaiGunu",
                column: "MesaiId",
                principalTable: "Mesai",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MesaiGunu_Mesai_MesaiId",
                table: "MesaiGunu");

            migrationBuilder.DropTable(
                name: "Mesai");

            migrationBuilder.DropIndex(
                name: "IX_MesaiGunu_MesaiId",
                table: "MesaiGunu");

            migrationBuilder.DropColumn(
                name: "MesaiId",
                table: "MesaiGunu");
        }
    }
}
