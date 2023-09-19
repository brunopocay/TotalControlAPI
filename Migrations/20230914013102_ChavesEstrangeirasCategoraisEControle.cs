using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TotalControlAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChavesEstrangeirasCategoraisEControle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PasswordSalt",
                table: "Users",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "ControleMensal",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "ControleMensal",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Categorias",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ControleMensal_UserId",
                table: "ControleMensal",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_UserId",
                table: "Categorias",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Users_UserId",
                table: "Categorias",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ControleMensal_Users_UserId",
                table: "ControleMensal",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Users_UserId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_ControleMensal_Users_UserId",
                table: "ControleMensal");

            migrationBuilder.DropIndex(
                name: "IX_ControleMensal_UserId",
                table: "ControleMensal");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_UserId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "ControleMensal");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ControleMensal");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Categorias");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "PasswordSalt",
                keyValue: null,
                column: "PasswordSalt",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordSalt",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "PasswordHash",
                keyValue: null,
                column: "PasswordHash",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
