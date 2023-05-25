using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class _alamat1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alamat_CalonPesertaDidik_CalonSiswaId",
                table: "Alamat");

            migrationBuilder.DropIndex(
                name: "IX_Alamat_CalonSiswaId",
                table: "Alamat");

            migrationBuilder.DropColumn(
                name: "CalonSiswaId",
                table: "Alamat");

            migrationBuilder.AddColumn<int>(
                name: "AlamatId",
                table: "CalonPesertaDidik",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CalonPesertaDidik_AlamatId",
                table: "CalonPesertaDidik",
                column: "AlamatId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalonPesertaDidik_Alamat_AlamatId",
                table: "CalonPesertaDidik",
                column: "AlamatId",
                principalTable: "Alamat",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalonPesertaDidik_Alamat_AlamatId",
                table: "CalonPesertaDidik");

            migrationBuilder.DropIndex(
                name: "IX_CalonPesertaDidik_AlamatId",
                table: "CalonPesertaDidik");

            migrationBuilder.DropColumn(
                name: "AlamatId",
                table: "CalonPesertaDidik");

            migrationBuilder.AddColumn<int>(
                name: "CalonSiswaId",
                table: "Alamat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Alamat_CalonSiswaId",
                table: "Alamat",
                column: "CalonSiswaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alamat_CalonPesertaDidik_CalonSiswaId",
                table: "Alamat",
                column: "CalonSiswaId",
                principalTable: "CalonPesertaDidik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
