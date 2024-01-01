using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje.Migrations
{
    public partial class UpdateMesaiGunu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MesaiGunu_Mesai_MesaiId",
                table: "MesaiGunu");

            migrationBuilder.AlterColumn<int>(
                name: "MesaiId",
                table: "MesaiGunu",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MesaiGunu_Mesai_MesaiId",
                table: "MesaiGunu",
                column: "MesaiId",
                principalTable: "Mesai",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MesaiGunu_Mesai_MesaiId",
                table: "MesaiGunu");

            migrationBuilder.AlterColumn<int>(
                name: "MesaiId",
                table: "MesaiGunu",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_MesaiGunu_Mesai_MesaiId",
                table: "MesaiGunu",
                column: "MesaiId",
                principalTable: "Mesai",
                principalColumn: "Id");
        }
    }
}
