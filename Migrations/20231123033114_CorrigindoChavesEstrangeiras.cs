using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TotalControlAPI.Migrations
{
    /// <inheritdoc />
    public partial class CorrigindoChavesEstrangeiras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroFinanceiroMensal_Categorias_CategoriasId",
                table: "RegistroFinanceiroMensal");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistroFinanceiroMensal_MesReferencia_MesReferenciaId",
                table: "RegistroFinanceiroMensal");

            migrationBuilder.DropIndex(
                name: "IX_RegistroFinanceiroMensal_CategoriasId",
                table: "RegistroFinanceiroMensal");

            migrationBuilder.DropIndex(
                name: "IX_RegistroFinanceiroMensal_MesReferenciaId",
                table: "RegistroFinanceiroMensal");

            migrationBuilder.DropColumn(
                name: "CategoriasId",
                table: "RegistroFinanceiroMensal");

            migrationBuilder.DropColumn(
                name: "MesReferenciaId",
                table: "RegistroFinanceiroMensal");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroFinanceiroMensal_CategoriaId",
                table: "RegistroFinanceiroMensal",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroFinanceiroMensal_MesId",
                table: "RegistroFinanceiroMensal",
                column: "MesId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroFinanceiroMensal_Categorias_CategoriaId",
                table: "RegistroFinanceiroMensal",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroFinanceiroMensal_MesReferencia_MesId",
                table: "RegistroFinanceiroMensal",
                column: "MesId",
                principalTable: "MesReferencia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegistroFinanceiroMensal_Categorias_CategoriaId",
                table: "RegistroFinanceiroMensal");

            migrationBuilder.DropForeignKey(
                name: "FK_RegistroFinanceiroMensal_MesReferencia_MesId",
                table: "RegistroFinanceiroMensal");

            migrationBuilder.DropIndex(
                name: "IX_RegistroFinanceiroMensal_CategoriaId",
                table: "RegistroFinanceiroMensal");

            migrationBuilder.DropIndex(
                name: "IX_RegistroFinanceiroMensal_MesId",
                table: "RegistroFinanceiroMensal");

            migrationBuilder.AddColumn<int>(
                name: "CategoriasId",
                table: "RegistroFinanceiroMensal",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MesReferenciaId",
                table: "RegistroFinanceiroMensal",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistroFinanceiroMensal_CategoriasId",
                table: "RegistroFinanceiroMensal",
                column: "CategoriasId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistroFinanceiroMensal_MesReferenciaId",
                table: "RegistroFinanceiroMensal",
                column: "MesReferenciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroFinanceiroMensal_Categorias_CategoriasId",
                table: "RegistroFinanceiroMensal",
                column: "CategoriasId",
                principalTable: "Categorias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegistroFinanceiroMensal_MesReferencia_MesReferenciaId",
                table: "RegistroFinanceiroMensal",
                column: "MesReferenciaId",
                principalTable: "MesReferencia",
                principalColumn: "Id");
        }
    }
}
