using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TotalControlAPI.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoTabelaControleMensalv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControleMensal_Categorias_NomeCategoriaId",
                table: "ControleMensal");

            migrationBuilder.DropIndex(
                name: "IX_ControleMensal_NomeCategoriaId",
                table: "ControleMensal");

            migrationBuilder.DropColumn(
                name: "NomeCategoriaId",
                table: "ControleMensal");

            migrationBuilder.AddColumn<string>(
                name: "NomeCategoria",
                table: "ControleMensal",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeCategoria",
                table: "ControleMensal");

            migrationBuilder.AddColumn<int>(
                name: "NomeCategoriaId",
                table: "ControleMensal",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ControleMensal_NomeCategoriaId",
                table: "ControleMensal",
                column: "NomeCategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ControleMensal_Categorias_NomeCategoriaId",
                table: "ControleMensal",
                column: "NomeCategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");
        }
    }
}
