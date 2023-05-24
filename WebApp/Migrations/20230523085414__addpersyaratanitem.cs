using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class _addpersyaratanitem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "TanggalLahir",
                table: "CalonPesertaDidik",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.CreateTable(
                name: "ItemPersyaratan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersyaratanId = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Jawaban = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CalonPesertaDidikId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPersyaratan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPersyaratan_CalonPesertaDidik_CalonPesertaDidikId",
                        column: x => x.CalonPesertaDidikId,
                        principalTable: "CalonPesertaDidik",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItemPersyaratan_Persyaratan_PersyaratanId",
                        column: x => x.PersyaratanId,
                        principalTable: "Persyaratan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPersyaratan_CalonPesertaDidikId",
                table: "ItemPersyaratan",
                column: "CalonPesertaDidikId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPersyaratan_PersyaratanId",
                table: "ItemPersyaratan",
                column: "PersyaratanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemPersyaratan");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TanggalLahir",
                table: "CalonPesertaDidik",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
