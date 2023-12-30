using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje.Migrations
{
    public partial class Duzeltme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Poliklinikler_PolikliniklerId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_PolikliniklerId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "PolikliniklerId",
                table: "Doctors");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_PoliklinikId",
                table: "Doctors",
                column: "PoliklinikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Poliklinikler_PoliklinikId",
                table: "Doctors",
                column: "PoliklinikId",
                principalTable: "Poliklinikler",
                principalColumn: "PolikliniklerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Poliklinikler_PoliklinikId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_PoliklinikId",
                table: "Doctors");

            migrationBuilder.AddColumn<int>(
                name: "PolikliniklerId",
                table: "Doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_PolikliniklerId",
                table: "Doctors",
                column: "PolikliniklerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Poliklinikler_PolikliniklerId",
                table: "Doctors",
                column: "PolikliniklerId",
                principalTable: "Poliklinikler",
                principalColumn: "PolikliniklerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
