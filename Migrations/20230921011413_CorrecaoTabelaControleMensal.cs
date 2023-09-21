using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TotalControlAPI.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoTabelaControleMensal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Receita",
                table: "ControleMensal",
                newName: "ValorDaConta");

            migrationBuilder.RenameColumn(
                name: "Despesas",
                table: "ControleMensal",
                newName: "TipoConta");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DiaInclusao",
                table: "ControleMensal",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ValorDaConta",
                table: "ControleMensal",
                newName: "Receita");

            migrationBuilder.RenameColumn(
                name: "TipoConta",
                table: "ControleMensal",
                newName: "Despesas");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DiaInclusao",
                table: "ControleMensal",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");
        }
    }
}
