using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje.Migrations
{
    public partial class AddRandevu : Migration
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

            migrationBuilder.CreateTable(
                name: "Randevu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    DoktorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Randevu_Doktor_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "Doktor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Randevu_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Randevu_DoktorId",
                table: "Randevu",
                column: "DoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevu_UserId",
                table: "Randevu",
                column: "UserId");

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

            migrationBuilder.DropTable(
                name: "Randevu");

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
