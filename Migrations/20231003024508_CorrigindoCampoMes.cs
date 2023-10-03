using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TotalControlAPI.Migrations
{
    /// <inheritdoc />
    public partial class CorrigindoCampoMes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ControleMensal_MesControle_MesId",
                table: "ControleMensal");

            migrationBuilder.DropIndex(
                name: "IX_ControleMensal_MesId",
                table: "ControleMensal");

            migrationBuilder.AddColumn<string>(
                name: "Mes",
                table: "ControleMensal",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mes",
                table: "ControleMensal");

            migrationBuilder.CreateIndex(
                name: "IX_ControleMensal_MesId",
                table: "ControleMensal",
                column: "MesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ControleMensal_MesControle_MesId",
                table: "ControleMensal",
                column: "MesId",
                principalTable: "MesControle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
