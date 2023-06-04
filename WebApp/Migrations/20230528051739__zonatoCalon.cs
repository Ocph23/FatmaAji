using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class _zonatoCalon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ZonasiId",
                table: "CalonPesertaDidik",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CalonPesertaDidik_ZonasiId",
                table: "CalonPesertaDidik",
                column: "ZonasiId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalonPesertaDidik_AntrianZonasi_ZonasiId",
                table: "CalonPesertaDidik",
                column: "ZonasiId",
                principalTable: "AntrianZonasi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalonPesertaDidik_AntrianZonasi_ZonasiId",
                table: "CalonPesertaDidik");

            migrationBuilder.DropIndex(
                name: "IX_CalonPesertaDidik_ZonasiId",
                table: "CalonPesertaDidik");

            migrationBuilder.DropColumn(
                name: "ZonasiId",
                table: "CalonPesertaDidik");
        }
    }
}
