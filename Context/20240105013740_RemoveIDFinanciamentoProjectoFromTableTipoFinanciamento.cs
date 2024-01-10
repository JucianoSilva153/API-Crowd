using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Context
{
    /// <inheritdoc />
    public partial class RemoveIDFinanciamentoProjectoFromTableTipoFinanciamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FinanciamentoProjectoId",
                table: "TiposFinanciamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FinanciamentoProjectoId",
                table: "TiposFinanciamento",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
