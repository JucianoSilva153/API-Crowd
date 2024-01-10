using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Context
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Genero = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ocupacao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FinanciadorId = table.Column<int>(type: "int", nullable: false),
                    RealizadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TiposFinanciador",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposFinanciador", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TiposFinanciamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FinanciamentoProjectoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposFinanciamento", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TiposProjecto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposProjecto", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Realizadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ContaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realizadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Realizadores_Contas_ContaId",
                        column: x => x.ContaId,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Financiadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ContaId = table.Column<int>(type: "int", nullable: false),
                    TipoFinanciadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Financiadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Financiadores_Contas_ContaId",
                        column: x => x.ContaId,
                        principalTable: "Contas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Financiadores_TiposFinanciador_TipoFinanciadorId",
                        column: x => x.TipoFinanciadorId,
                        principalTable: "TiposFinanciador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FundoPretendido = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoProjectoId = table.Column<int>(type: "int", nullable: false),
                    RealizadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projetos_Realizadores_RealizadorId",
                        column: x => x.RealizadorId,
                        principalTable: "Realizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projetos_TiposProjecto_TipoProjectoId",
                        column: x => x.TipoProjectoId,
                        principalTable: "TiposProjecto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FinanciamentosProjecto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TipoFinanciamentoId = table.Column<int>(type: "int", nullable: false),
                    FinanciadorId = table.Column<int>(type: "int", nullable: false),
                    ProjectoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanciamentosProjecto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinanciamentosProjecto_Financiadores_FinanciadorId",
                        column: x => x.FinanciadorId,
                        principalTable: "Financiadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinanciamentosProjecto_Projetos_ProjectoId",
                        column: x => x.ProjectoId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinanciamentosProjecto_TiposFinanciamento_TipoFinanciamentoId",
                        column: x => x.TipoFinanciamentoId,
                        principalTable: "TiposFinanciamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Detalhes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FinanciamentoProjectoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalhes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detalhes_FinanciamentosProjecto_FinanciamentoProjectoId",
                        column: x => x.FinanciamentoProjectoId,
                        principalTable: "FinanciamentosProjecto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Verificacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Detalhes = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoVerificacao = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Verificado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ProjectoId = table.Column<int>(type: "int", nullable: true),
                    FinanciamentoProjectoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Verificacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Verificacoes_FinanciamentosProjecto_FinanciamentoProjectoId",
                        column: x => x.FinanciamentoProjectoId,
                        principalTable: "FinanciamentosProjecto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Verificacoes_Projetos_ProjectoId",
                        column: x => x.ProjectoId,
                        principalTable: "Projetos",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Detalhes_FinanciamentoProjectoId",
                table: "Detalhes",
                column: "FinanciamentoProjectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Financiadores_ContaId",
                table: "Financiadores",
                column: "ContaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Financiadores_TipoFinanciadorId",
                table: "Financiadores",
                column: "TipoFinanciadorId");

            migrationBuilder.CreateIndex(
                name: "IX_FinanciamentosProjecto_FinanciadorId",
                table: "FinanciamentosProjecto",
                column: "FinanciadorId");

            migrationBuilder.CreateIndex(
                name: "IX_FinanciamentosProjecto_ProjectoId",
                table: "FinanciamentosProjecto",
                column: "ProjectoId");

            migrationBuilder.CreateIndex(
                name: "IX_FinanciamentosProjecto_TipoFinanciamentoId",
                table: "FinanciamentosProjecto",
                column: "TipoFinanciamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_RealizadorId",
                table: "Projetos",
                column: "RealizadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_TipoProjectoId",
                table: "Projetos",
                column: "TipoProjectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Realizadores_ContaId",
                table: "Realizadores",
                column: "ContaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Verificacoes_FinanciamentoProjectoId",
                table: "Verificacoes",
                column: "FinanciamentoProjectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Verificacoes_ProjectoId",
                table: "Verificacoes",
                column: "ProjectoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalhes");

            migrationBuilder.DropTable(
                name: "Verificacoes");

            migrationBuilder.DropTable(
                name: "FinanciamentosProjecto");

            migrationBuilder.DropTable(
                name: "Financiadores");

            migrationBuilder.DropTable(
                name: "Projetos");

            migrationBuilder.DropTable(
                name: "TiposFinanciamento");

            migrationBuilder.DropTable(
                name: "TiposFinanciador");

            migrationBuilder.DropTable(
                name: "Realizadores");

            migrationBuilder.DropTable(
                name: "TiposProjecto");

            migrationBuilder.DropTable(
                name: "Contas");
        }
    }
}
