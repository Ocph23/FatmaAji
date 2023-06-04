using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class _addInformasiTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Pesan",
                table: "Informasi",
                newName: "Judul");

            migrationBuilder.AddColumn<string>(
                name: "Isi",
                table: "Informasi",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Isi",
                table: "Informasi");

            migrationBuilder.RenameColumn(
                name: "Judul",
                table: "Informasi",
                newName: "Pesan");
        }
    }
}
