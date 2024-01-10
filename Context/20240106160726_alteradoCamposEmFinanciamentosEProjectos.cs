using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Context
{
    /// <inheritdoc />
    public partial class alteradoCamposEmFinanciamentosEProjectos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "estado",
                table: "FinanciamentosProjecto",
                newName: "doacao");

            migrationBuilder.AddColumn<string>(
                name: "estadoFinanciamento",
                table: "Projetos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "estadoFinanciamento",
                table: "Projetos");

            migrationBuilder.RenameColumn(
                name: "doacao",
                table: "FinanciamentosProjecto",
                newName: "estado");
        }
    }
}
