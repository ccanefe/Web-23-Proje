using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proje.Migrations
{
    public partial class UpdateUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnaBilimDali",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnaBilimDaliAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnaBilimDali", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Poliklinikler",
                columns: table => new
                {
                    PolikliniklerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliklinikAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnaBilimDaliId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poliklinikler", x => x.PolikliniklerId);
                    table.ForeignKey(
                        name: "FK_Poliklinikler_AnaBilimDali_AnaBilimDaliId",
                        column: x => x.AnaBilimDaliId,
                        principalTable: "AnaBilimDali",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnaBilimDaliId = table.Column<int>(type: "int", nullable: false),
                    PolikliniklerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_AnaBilimDali_AnaBilimDaliId",
                        column: x => x.AnaBilimDaliId,
                        principalTable: "AnaBilimDali",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Poliklinikler_PolikliniklerId",
                        column: x => x.PolikliniklerId,
                        principalTable: "Poliklinikler",
                        principalColumn: "PolikliniklerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CalismaZamani",
                columns: table => new
                {
                    CalismaZamaniId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalistigiGunler = table.Column<int>(type: "int", nullable: false),
                    BaslangicZamani = table.Column<TimeSpan>(type: "time", nullable: false),
                    BitisZamani = table.Column<TimeSpan>(type: "time", nullable: false),
                    DoktorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalismaZamani", x => x.CalismaZamaniId);
                    table.ForeignKey(
                        name: "FK_CalismaZamani_Doctors_DoktorId",
                        column: x => x.DoktorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Randevu",
                columns: table => new
                {
                    RandevuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    DoctorsId = table.Column<int>(type: "int", nullable: false),
                    PoliklinikId = table.Column<int>(type: "int", nullable: false),
                    PolikliniklerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevu", x => x.RandevuId);
                    table.ForeignKey(
                        name: "FK_Randevu_Doctors_DoctorsId",
                        column: x => x.DoctorsId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevu_Poliklinikler_PolikliniklerId",
                        column: x => x.PolikliniklerId,
                        principalTable: "Poliklinikler",
                        principalColumn: "PolikliniklerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevu_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalismaZamani_DoktorId",
                table: "CalismaZamani",
                column: "DoktorId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_AnaBilimDaliId",
                table: "Doctors",
                column: "AnaBilimDaliId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_PolikliniklerId",
                table: "Doctors",
                column: "PolikliniklerId");

            migrationBuilder.CreateIndex(
                name: "IX_Poliklinikler_AnaBilimDaliId",
                table: "Poliklinikler",
                column: "AnaBilimDaliId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevu_DoctorsId",
                table: "Randevu",
                column: "DoctorsId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevu_PolikliniklerId",
                table: "Randevu",
                column: "PolikliniklerId");

            migrationBuilder.CreateIndex(
                name: "IX_Randevu_UserId",
                table: "Randevu",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalismaZamani");

            migrationBuilder.DropTable(
                name: "Randevu");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Poliklinikler");

            migrationBuilder.DropTable(
                name: "AnaBilimDali");
        }
    }
}
