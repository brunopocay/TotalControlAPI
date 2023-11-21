using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TotalControlAPI.Migrations
{
    /// <inheritdoc />
    public partial class MelhorandoRelacionamentoDeEntidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Endereco_EnderecoId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "ControleMensal");

            migrationBuilder.DropTable(
                name: "MesControle");

            migrationBuilder.DropIndex(
                name: "IX_Users_EnderecoId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Endereco",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MesReferencia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    NomeMes = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ano = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ControleAtivo = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MesReferencia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MesReferencia_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RegistroFinanceiroMensal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    CategoriasId = table.Column<int>(type: "int", nullable: true),
                    TipoConta = table.Column<int>(type: "int", nullable: false),
                    MesId = table.Column<int>(type: "int", nullable: false),
                    MesReferenciaId = table.Column<int>(type: "int", nullable: true),
                    DiaInclusao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValorDaConta = table.Column<int>(type: "int", nullable: false),
                    Saldo = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroFinanceiroMensal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistroFinanceiroMensal_Categorias_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "Categorias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistroFinanceiroMensal_MesReferencia_MesReferenciaId",
                        column: x => x.MesReferenciaId,
                        principalTable: "MesReferencia",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RegistroFinanceiroMensal_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_UserId",
                table: "Endereco",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MesReferencia_UserId",
                table: "MesReferencia",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroFinanceiroMensal_CategoriasId",
                table: "RegistroFinanceiroMensal",
                column: "CategoriasId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroFinanceiroMensal_MesReferenciaId",
                table: "RegistroFinanceiroMensal",
                column: "MesReferenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroFinanceiroMensal_UserId",
                table: "RegistroFinanceiroMensal",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Users_UserId",
                table: "Endereco",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Users_UserId",
                table: "Endereco");

            migrationBuilder.DropTable(
                name: "RegistroFinanceiroMensal");

            migrationBuilder.DropTable(
                name: "MesReferencia");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_UserId",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Endereco");

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ControleMensal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DiaInclusao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MesId = table.Column<int>(type: "int", nullable: false),
                    NomeCategoria = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Saldo = table.Column<int>(type: "int", nullable: false),
                    TipoConta = table.Column<int>(type: "int", nullable: false),
                    ValorDaConta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ControleMensal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ControleMensal_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MesControle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ControleAtivo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Mes = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MesControle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MesControle_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Users_EnderecoId",
                table: "Users",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_ControleMensal_UserId",
                table: "ControleMensal",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MesControle_UserId",
                table: "MesControle",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Endereco_EnderecoId",
                table: "Users",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id");
        }
    }
}
