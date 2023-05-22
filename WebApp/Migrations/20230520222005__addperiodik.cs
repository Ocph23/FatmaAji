using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class _addperiodik : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Pekerjaan",
                table: "OrangTua",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Penghasilan",
                table: "OrangTua",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PeriodikId",
                table: "CalonPesertaDidik",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TK",
                table: "CalonPesertaDidik",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Periodik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tinggi = table.Column<double>(type: "double", nullable: false),
                    LingkarKepala = table.Column<double>(type: "double", nullable: false),
                    Berat = table.Column<double>(type: "double", nullable: false),
                    JarakKeSekolah = table.Column<double>(type: "double", nullable: false),
                    WaktuTempuh = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    JumlahSaudara = table.Column<int>(type: "int", nullable: false),
                    DariTK = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periodik", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_CalonPesertaDidik_PeriodikId",
                table: "CalonPesertaDidik",
                column: "PeriodikId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalonPesertaDidik_Periodik_PeriodikId",
                table: "CalonPesertaDidik",
                column: "PeriodikId",
                principalTable: "Periodik",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalonPesertaDidik_Periodik_PeriodikId",
                table: "CalonPesertaDidik");

            migrationBuilder.DropTable(
                name: "Periodik");

            migrationBuilder.DropIndex(
                name: "IX_CalonPesertaDidik_PeriodikId",
                table: "CalonPesertaDidik");

            migrationBuilder.DropColumn(
                name: "Pekerjaan",
                table: "OrangTua");

            migrationBuilder.DropColumn(
                name: "Penghasilan",
                table: "OrangTua");

            migrationBuilder.DropColumn(
                name: "PeriodikId",
                table: "CalonPesertaDidik");

            migrationBuilder.DropColumn(
                name: "TK",
                table: "CalonPesertaDidik");
        }
    }
}
