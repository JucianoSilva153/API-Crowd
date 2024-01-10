using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Context
{
    /// <inheritdoc />
    public partial class addDataMetaToProjecto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "dataMeta",
                table: "Projetos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dataMeta",
                table: "Projetos");
        }
    }
}
