using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Context
{
    /// <inheritdoc />
    public partial class AddNovosCamposEmContaEFinanciamentoProjecto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataCriacao",
                table: "FinanciamentosProjecto",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "estado",
                table: "FinanciamentosProjecto",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "BilheteIdentidade",
                table: "Contas",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Contacto",
                table: "Contas",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Contas",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "FinanciamentosProjecto");

            migrationBuilder.DropColumn(
                name: "estado",
                table: "FinanciamentosProjecto");

            migrationBuilder.DropColumn(
                name: "BilheteIdentidade",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "Contacto",
                table: "Contas");

            migrationBuilder.DropColumn(
                name: "password",
                table: "Contas");
        }
    }
}
