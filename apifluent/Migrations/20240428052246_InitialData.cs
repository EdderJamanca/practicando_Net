using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apifluent.Migrations
{
    /// <inheritdoc />
    public partial class InitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_Categoria_CategoriaId1",
                table: "Tarea");

            migrationBuilder.DropIndex(
                name: "IX_Tarea_CategoriaId1",
                table: "Tarea");

            migrationBuilder.DropColumn(
                name: "CategoriaId1",
                table: "Tarea");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoriaId",
                table: "Tarea",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_CategoriaId",
                table: "Tarea",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_Categoria_CategoriaId",
                table: "Tarea",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarea_Categoria_CategoriaId",
                table: "Tarea");

            migrationBuilder.DropIndex(
                name: "IX_Tarea_CategoriaId",
                table: "Tarea");

            migrationBuilder.AlterColumn<string>(
                name: "CategoriaId",
                table: "Tarea",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoriaId1",
                table: "Tarea",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_CategoriaId1",
                table: "Tarea",
                column: "CategoriaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarea_Categoria_CategoriaId1",
                table: "Tarea",
                column: "CategoriaId1",
                principalTable: "Categoria",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
